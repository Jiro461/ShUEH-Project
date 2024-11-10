using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Utilities.Extensions;

namespace BackEnd_ASP.NET.Services
{
    public class ShoeService : ControllerBase, IShoeService
    {
        // Khai báo các dịch vụ cần thiết
        private readonly IShoeRepository shoeRepository; // Repository để thao tác với dữ liệu giày
        private readonly ShUEHContext context; // Context của EF Core để thao tác với cơ sở dữ liệu
        private readonly INotificationService notificationService; // Dịch vụ thông báo
        private readonly IWebHostEnvironment webHostEnvironment; // Dịch vụ môi trường web để xử lý tệp
        private readonly ILogger<ShoeService> logger; // Dịch vụ logging để ghi lại các thông tin log

        // Constructor nhận các tham số để khởi tạo dịch vụ
        public ShoeService(IShoeRepository shoeRepository, ShUEHContext context, INotificationService notificationService, IWebHostEnvironment webHostEnvironment, ILogger<ShoeService> logger)
        {
            this.shoeRepository = shoeRepository;
            this.context = context;
            this.notificationService = notificationService;
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }

        // Lấy tất cả giày từ kho
        public async Task<IEnumerable<ShoeGetAllDTO>?> GetAllShoesAsync(Guid? userId = null, int page = -1, int pageSize = -1)
        {
            logger.LogInformation($"GetAllShoesAsync called with userId: {userId}"); // Log thông tin khi gọi phương thức
            var shoes = await shoeRepository.GetAllShoesAsync(page, pageSize); // Lấy tất cả giày từ repository
            IEnumerable<ShoeGetAllDTO>? shoesDTO;

            // Kiểm tra nếu có userId thì lọc giày theo người dùng
            if (userId != null)
            {
                shoesDTO = GetAllShoeByUserID(shoes, userId); // Lọc giày theo người dùng
                if (shoesDTO == null) return null;
                return shoesDTO;
            }

            // Nếu không có userId, trả về tất cả giày
            shoesDTO = ConvertListToListShoeGetAllDTOForUser(shoes.ToList(), null);
            if (shoesDTO == null) return null;
            return shoesDTO;
        }

        // Lọc giày theo người dùng
        private IEnumerable<ShoeGetAllDTO>? GetAllShoeByUserID(IEnumerable<Shoe> shoes, Guid? userId)
        {
            if (userId == null) return null;
            var user = context.Users.FirstOrDefault(user => user.Id == userId); // Lấy thông tin người dùng
            if (user == null) return null;
            var genderBinding = user.Gender.GenderBinding(); // Lấy giới tính người dùng
            var userWishlist = context.WishlistItems.Where(userWishlist => userWishlist.UserId == userId).Select(userWishlist => userWishlist.ShoeId).ToList(); // Lấy danh sách giày trong wishlist của người dùng
            shoes = shoes.OrderByDescending(shoe => shoe.Gender == genderBinding || shoe.Gender == 2); // Lọc giày theo giới tính của người dùng
            return ConvertListToListShoeGetAllDTOForUser(shoes.ToList(), userId); // Chuyển đổi danh sách giày thành DTO
        }

        // Lấy giày theo ID cho người dùng
        public async Task<IActionResult> GetShoeByIdFromUserAsync(Guid id, Guid? userId = null)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id); // Lấy giày theo ID từ repository
            if (shoe == null)
                return NotFound($"Shoe with ID {id} not found."); // Trả về NotFound nếu không tìm thấy giày

            var shoeDTO = ConvertShoeToShoeGetDTO(shoe, userId); // Chuyển giày thành DTO
            if (shoeDTO == null) return NotFound($"Shoe with ID {id} not found.");
            return Ok(shoeDTO); // Trả về giày dưới dạng DTO
        }

         // Lấy giày theo ID cho Admin
        public async Task<IActionResult> GetShoeByIdFromAdminAsync(Guid id)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id); // Lấy giày theo ID từ repository
            if (shoe == null) return NotFound($"Shoe with ID {id} not found.");

            var shoeDTO = ConvertShoeToShoeGetDTO(shoe, null); // Chuyển giày thành DTO
            if (shoeDTO == null) return NotFound($"Shoe with ID {id} not found.");

            // Lấy dữ liệu lượt xem và đơn hàng theo tháng
            var shoeViewByMonth = await context.ProductViews
                .Where(view => view.ProductId == id && view.ViewedDate.Month <= DateTime.Now.Month)
                .GroupBy(view => view.ViewedDate.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    ViewCount = group.Count()
                })
                .ToListAsync();

            var shoeOrderByMonth = await context.OrderItems
                .Join(context.Orders, oi => oi.OrderId, o => o.Id, (oi, o) => new { oi, o })
                .Where(x => x.oi.ShoeId == id)
                .GroupBy(x => x.o.OrderDate.Month) 
                .Select(g => new
                {
                    Month = g.Key,
                    TotalQuantity = g.Sum(x => x.oi.Quantity) 
                })
                .ToListAsync();

            // Kết hợp dữ liệu lượt xem và đơn hàng theo tháng
            var result = shoeViewByMonth
                    .GroupJoin(shoeOrderByMonth,
                        view => view.Month,
                        order => order.Month,
                        (view, orders) => new
                        {
                            Month = view.Month,
                            Visits = view.ViewCount,
                            Orders = orders.FirstOrDefault()?.TotalQuantity ?? 0 
                        })
                    .ToList();

            if (!result.Any())
            {
                return NotFound($"Shoe with ID {id} does not have data for views or orders.");
            }

            // Trả về kết quả bao gồm thông tin giày và biểu đồ
            var response = new
            {
                shoeDTO,
                chart = result
            };

            return Ok(response);
        }

        // Thêm một đôi giày mới
        public async Task<IActionResult> AddShoeAsync(ShoePostDTO shoe)
        {
            if (shoe == null)
                return BadRequest("Shoe data is required."); // Kiểm tra dữ liệu giày có hợp lệ không
            if (!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình

            var existingShoe = context.Shoes.Where(s => s.Name == shoe.Name && s.Brand == shoe.Brand).FirstOrDefault(); // Kiểm tra giày đã tồn tại chưa
            if (existingShoe != null)
                return BadRequest("Shoe already exists, using another name or brand.");

            // Tạo một giày mới
            Guid newShoeId = Guid.NewGuid();
            var newShoe = new Shoe
            {
                Id = newShoeId,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Material = shoe.Material,
                Category = shoe.Category,
                ImageUrl = await FileHelper.AddShoeImageAsync(webHostEnvironment, newShoeId, shoe), // Thêm ảnh giày
                Description = shoe.Description,
                Price = shoe.Price,
                IsSale = shoe.IsSale,
                shoeDetails = shoe.shoeDetails.Select(detail => new ShoeDetail
                {
                    Id = Guid.NewGuid(),
                    Size = detail.Size,
                    Quantity = detail.Quantity
                }).ToList(),
                Sold = 0,
                Discount = shoe.Discount,
                Colors = shoe.Colors.Select(color => new ShoeColor
                {
                    Id = Guid.NewGuid(),
                    Color = color.Color,
                    ShoeId = newShoeId
                }).ToList(),
                Seasons = shoe.Seasons.Select(season => new ShoeSeason
                {
                    Id = Guid.NewGuid(),
                    Season = season.Season,
                    ShoeId = newShoeId
                }).ToList()
            };

            await AddShoeImageAsync(newShoe, shoe); // Thêm các chi tiết ảnh
            await shoeRepository.AddShoeAsync(newShoe); // Lưu giày mới vào cơ sở dữ liệu
            await notificationService.CreateNotificationForShoe(newShoe); // Tạo thông báo khi có giày mới
            return Ok("Shoe created successfully"); // Trả về thông báo thành công
        }

        // Cập nhật thông tin một đôi giày
        public async Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO updateShoe)
        {
            var existingShoe = await shoeRepository.GetShoeByIdAsync(shoeId);
            if (existingShoe == null)
                return NotFound($"Shoe with ID {shoeId} not found."); // Kiểm tra giày tồn tại
            if (!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình

            // Cập nhật các thuộc tính cơ bản
            existingShoe.Name = updateShoe.Name;
            existingShoe.Brand = updateShoe.Brand;
            existingShoe.Material = updateShoe.Material;
            existingShoe.Category = updateShoe.Category;
            existingShoe.Description = updateShoe.Description;
            existingShoe.Price = updateShoe.Price;
            existingShoe.IsSale = updateShoe.IsSale;
            existingShoe.Discount = updateShoe.Discount;

            // Cập nhật Colors
            existingShoe.Colors.Clear();
            foreach (var color in updateShoe.Colors)
            {
                existingShoe.Colors.Add(new ShoeColor { Color = color.Color, ShoeId = existingShoe.Id });
            }

            // Cập nhật MainImage và AdditionalImages
            if (updateShoe.MainImage != null)
                existingShoe.ImageUrl = await FileHelper.UpdateShoeImageAsync(webHostEnvironment, existingShoe, updateShoe);
            
            if (updateShoe.AdditionalImages != null)
                existingShoe.OtherImages = await UpdateShoeImageAsync(existingShoe, updateShoe);

            // Cập nhật ShoeDetails
            existingShoe.shoeDetails.Clear();
            foreach (var detail in updateShoe.shoeDetails)
            {
                var shoeDetail = existingShoe.shoeDetails.FirstOrDefault(d => d.Size == detail.Size);
                if (shoeDetail != null)
                {
                    shoeDetail.Quantity = detail.Quantity;
                }
                else
                {
                    existingShoe.shoeDetails.Add(new ShoeDetail
                    {
                        Size = detail.Size,
                        Quantity = detail.Quantity,
                        ShoeId = existingShoe.Id
                    });
                }
            }

            // Cập nhật Seasons
            existingShoe.Seasons.Clear();
            foreach (var season in updateShoe.Seasons)
            {
                existingShoe.Seasons.Add(new ShoeSeason { Season = season.Season, ShoeId = existingShoe.Id });
            }

            await shoeRepository.UpdateShoeAsync(existingShoe); // Cập nhật giày trong kho
            await notificationService.CreateUpdateNotificationForEntityChange(existingShoe);
            return Ok("Shoe updated successfully"); // Trả về thông báo thành công
        }
        public async Task<IEnumerable<ShoeGetAllDTO>> GetSimilarShoes(Guid shoeId)
        {
            // Lấy giày hiện tại
            var currentShoe = await context.Shoes.FindAsync(shoeId);
            if (currentShoe == null) return Enumerable.Empty<ShoeGetAllDTO>();

            // Truy vấn các giày tương tự
            var similarShoes = await context.Shoes
                .Where(s => s.Id != shoeId
                    && (s.Brand == currentShoe.Brand || s.Category == currentShoe.Category || s.Gender == currentShoe.Gender))
                .OrderByDescending(s => s.Sold) // ưu tiên giày phổ biến hơn
                .Take(5) // giới hạn số lượng
                .ToListAsync();

            return ConvertListToListShoeGetAllDTOForUser(similarShoes);
        }
        // Xóa một đôi giày
        public async Task<IActionResult> DeleteShoeAsync(Guid id)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id);
            if (shoe == null)
                return NotFound($"Shoe with ID {id} not found."); // Kiểm tra giày tồn tại

            var result = await shoeRepository.DeleteShoeAsync(id);
            if (!result)
                return NotFound($"Shoe with ID {id} not found."); // Kiểm tra giày tồn tại
            await notificationService.CreateNotificationForEntityDelete(shoe);
            return Ok("Shoe deleted successfully"); // Trả về thông báo thành công
        }


        // Hàm phụ trợ để thêm các chi tiết của giày
        private async Task AddShoeImageAsync(Shoe newShoe, ShoePostDTO shoe)
        {
            try
            {
                // Thêm hình ảnh giày
                if (shoe.AdditionalImages != null)
                {
                    for (int i = 0; i < shoe.AdditionalImages.Count; i++)
                    {
                        var imageUrl = await FileHelper.AddShoeOtherImageAsync(webHostEnvironment, newShoe.Id, shoe.AdditionalImages[i], i);
                        newShoe.OtherImages.Add(new ShoeImage { Url = imageUrl, Shoe = newShoe });
                    }

                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new InvalidOperationException("Failed to add shoe details.", ex);
            }
        }
        //Cập nhật ảnh giày
        private async Task<List<ShoeImage>> UpdateShoeImageAsync(Shoe existingShoe, ShoePostDTO updateShoe)
        {
            var newImages = updateShoe.AdditionalImages;
            var newImagesList = new List<ShoeImage>();
            //Cập nhật ảnh giày mới
            for (int i = 0; i < newImages?.Count; i++)
            {
                if (updateShoe.AdditionalImages != null)
                {
                    newImagesList.Add(new ShoeImage
                    {
                        Url =
                    await FileHelper
                    .UpdateShoeOtherImageAsync(webHostEnvironment, existingShoe.OtherImages
                    .ElementAt(i), updateShoe.AdditionalImages[i], i),
                        Shoe = existingShoe
                    });
                }
            }
            return newImagesList;
        }
        //Chuyển đổi giày thành DTO cho người dùng
        public ShoeGetDTO? ConvertShoeToShoeGetDTO(Shoe shoe, Guid? userId = null)
        {
            var userWishlist = userId != null ? context.WishlistItems.Where(userWishlist => userWishlist.UserId == userId).Select(userWishlist => userWishlist.ShoeId).ToList() : null;
            var shoeDTO = new ShoeGetDTO
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Material = shoe.Material ?? string.Empty,
                Category = shoe.Category ?? string.Empty,
                IsSale = shoe.Discount > 0 && shoe.Discount < 100,
                Discount = shoe.Discount,
                ViewCount = shoe.ViewCount,
                Price = shoe.Price,
                IsLiked = userWishlist != null ? userWishlist.Contains(shoe.Id) : false,
                SalePrice = shoe.IsSale ? shoe.Price * (1 - shoe.Discount / 100) : null,
                CreateDate = shoe.CreateDate,
                TotalRatings = shoe.Comments?.Count ?? 0,
                AverageRating = shoe.AverageRating,
                Sold = shoe.Sold,
                ImageUrl = shoe.ImageUrl ?? string.Empty,
                Description = shoe.Description ?? string.Empty,
                OtherImages = shoe.OtherImages == null ? null : shoe.OtherImages.Select(image => new ShoeImageDTO
                {
                    Url = image.Url
                }).ToList(),
                shoeDetails = shoe.shoeDetails == null ? null : shoe.shoeDetails.Select(detail => new ShoeDetailDTO
                {
                    Size = detail.Size,
                    Quantity = detail.Quantity
                }).ToList(),
                Seasons = shoe.Seasons == null ? null : shoe.Seasons.Select(season => new ShoeSeasonDTO
                {
                    Season = season.Season
                }).ToList(),
                Colors = shoe.Colors == null ? null : shoe.Colors.Select(color => new ShoeColorDTO
                {
                    Color = color.Color
                }).ToList(),
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14)
            };
            return shoeDTO;
        }
        // Chuyển đổi danh sách giày thành DTO cho admin
        public List<ShoeGetAllDTO> ConvertListToListShoeGetAllDTOForAdmin(List<Shoe> shoes, Guid? userId = null)
        {
            var userWishlist = userId != null ? context.WishlistItems.Where(userWishlist => userWishlist.UserId == userId).Select(userWishlist => userWishlist.ShoeId).ToList() : null;
            return shoes.Select(shoe => new ShoeGetAllDTO
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Material = shoe.Material ?? string.Empty,
                Category = shoe.Category ?? string.Empty,
                Gender = shoe.Gender,
                ImageUrl = shoe.ImageUrl ?? string.Empty,
                Price = shoe.Price,
                AverageRating = shoe.AverageRating,
                TotalRatings = shoe.Comments?.Count ?? 0,
                Sold = shoe.Sold,
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14),
                IsSale = shoe.IsSale,
                Discount = shoe.Discount,
                IsLiked = userWishlist != null ? userWishlist.Contains(shoe.Id) : false,
            }).ToList();
        }
        //Chuyển đổi danh sách giày thành DTO cho người dùng
        public List<ShoeGetAllDTO> ConvertListToListShoeGetAllDTOForUser(List<Shoe> shoes, Guid? userId = null)
        {
            var userWishlist = userId != null ? context.WishlistItems.Where(userWishlist => userWishlist.UserId == userId).Select(userWishlist => userWishlist.ShoeId).ToList() : null;
            return shoes.Select(shoe => new ShoeGetAllDTO
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Material = shoe.Material ?? string.Empty,
                Category = shoe.Category ?? string.Empty,
                ImageUrl = shoe.ImageUrl ?? string.Empty,
                AverageRating = shoe.AverageRating,
                TotalRatings = shoe.Comments?.Count ?? 0,
                Sold = shoe.Sold,
                Price = shoe.Price,
                SalePrice = shoe.IsSale ? shoe.Price * (1 - shoe.Discount / 100) : null,
                IsSale = shoe.IsSale,
                Discount = shoe.Discount,
                Seasons = shoe.Seasons.Select(season => new ShoeSeasonDTO
                {
                    Season = season.Season
                }).ToList(),
                Colors = shoe.Colors.Select(color => new ShoeColorDTO
                {
                    Color = color.Color
                }).ToList(),
                shoeDetails = shoe.shoeDetails.Select(detail => new ShoeDetailDTO
                {
                    Size = detail.Size,
                    Quantity = detail.Quantity
                }).ToList(),
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14),
                IsLiked = userWishlist != null ? userWishlist.Contains(shoe.Id) : false
            }).ToList();
        }
    }

}
