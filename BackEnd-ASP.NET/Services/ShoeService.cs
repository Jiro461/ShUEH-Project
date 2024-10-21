using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;

namespace BackEnd_ASP.NET.Services
{
    public class ShoeService : ControllerBase, IShoeService
    {
        private readonly IShoeRepository shoeRepository; // Repository để thao tác với dữ liệu giày
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ShoeService(IShoeRepository shoeRepository, ShUEHContext context, INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            this.shoeRepository = shoeRepository;
            this.context = context;
            this.notificationService = notificationService;
            this.webHostEnvironment = webHostEnvironment;
        }

        // Lấy tất cả giày từ kho
        public async Task<IActionResult> GetAllShoesAsync()
        {
            var shoes = await shoeRepository.GetAllShoesAsync();
            return Ok(shoes); // Trả về danh sách giày
        }

        // Lấy giày theo ID
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id);
            if (shoe == null)
                return NotFound($"Shoe with ID {id} not found."); // Trả về NotFound nếu không tìm thấy
            return Ok(shoe); // Trả về giày nếu tìm thấy
        }

        // Thêm một đôi giày mới
        public async Task<IActionResult> AddShoeAsync(ShoePostDTO shoe)
        {
            if (shoe == null)
                return BadRequest("Shoe data is required."); // Kiểm tra dữ liệu đầu vào
            if (!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình

            // Tạo một đối tượng giày mới
            var newshoeDetails = shoe.shoeDetails.Select(detail => new ShoeDetail
            {
                Id = Guid.NewGuid(),
                Size = detail.Size,
                Quantity = detail.Quantity
            }).ToList();
            Guid newShoeId = Guid.NewGuid();
            var newShoe = new Shoe
            {
                Id = newShoeId,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Material = shoe.Material,
                Category = shoe.Category,
                ImageUrl = await FileHelper.AddShoeImageAsync(webHostEnvironment, newShoeId, shoe),
                Description = shoe.Description,
                Price = shoe.Price,
                IsSale = shoe.IsSale,
                shoeDetails = newshoeDetails,
                Discount = shoe.Discount,
                Colors = shoe.Colors.Select(color => new ShoeColor
                {
                    Id = Guid.NewGuid(),
                    Color = color.Color,
                    ShoeId = newShoeId
                }).ToList()
            };

            await AddShoeDetailsAsync(newShoe, shoe); // Thêm các chi tiết của giày
            await shoeRepository.AddShoeAsync(newShoe); // Thêm giày vào kho
            await notificationService.CreateNotificationForShoe(newShoe);
            return Ok("Shoe created successfully"); // Trả về 201 Created
        }

        // Cập nhật thông tin một đôi giày
        public async Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO updateShoe)
        {
            var existingShoe = await context.Shoes.Where(s => s.Id == shoeId)
                                            .Include(s => s.shoeDetails)
                                            .Include(s => s.Seasons)
                                            .Include(s => s.Colors)
                                            .Include(s => s.OtherImages)
                                            .FirstOrDefaultAsync();
            if (existingShoe == null)
                return NotFound($"Shoe with ID {shoeId} not found."); // Kiểm tra giày tồn tại
            if (!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình
            // Cập nhật thông tin giày
            existingShoe.Name = updateShoe.Name;
            existingShoe.Brand = updateShoe.Brand;
            existingShoe.Material = updateShoe.Material;
            existingShoe.Category = updateShoe.Category;
            existingShoe.Description = updateShoe.Description;
            existingShoe.Price = updateShoe.Price;
            existingShoe.IsSale = updateShoe.IsSale;
            existingShoe.Discount = updateShoe.Discount;
            existingShoe.Colors = updateShoe.Colors.Select(color => new ShoeColor
            {
                Color = color.Color,
                ShoeId = existingShoe.Id
            }).ToList();
            existingShoe.ImageUrl = await FileHelper.UpdateShoeImageAsync(webHostEnvironment, existingShoe, updateShoe);

            var newImages = updateShoe.AdditionalImages;
            var newImagesList = new List<ShoeImage>();

            for(int i = 0; i < newImages?.Count; i++)
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

            existingShoe.OtherImages = newImagesList;
            
            var updatedShoeDetails = updateShoe.shoeDetails.Select(detail => new ShoeDetail
            {
                Id = existingShoe.shoeDetails.FirstOrDefault(d => d.Size == detail.Size)?.Id ?? Guid.NewGuid(),
                Shoe = existingShoe,
                Size = detail.Size,
                Quantity = detail.Quantity
            }).ToList();
            existingShoe.shoeDetails = updatedShoeDetails;
            // Xử lý các thuộc tính Colors, Seasons và Sizes
            var updatedShoeSeasons = updateShoe.Seasons.Select(season => new ShoeSeason
            {
                Season = season.Season,
                Shoe = existingShoe
            }).ToList();
            existingShoe.Seasons = updatedShoeSeasons;

            await shoeRepository.UpdateShoeAsync(existingShoe); // Cập nhật giày trong kho
            await notificationService.CreateUpdateNotificationForEntityChange(existingShoe);
            return Ok("Shoe updated successfully"); // Trả về thông báo thành công
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
        private async Task AddShoeDetailsAsync(Shoe newShoe, ShoePostDTO shoe)
        {
            try
            {
                var shoeDetails = AddShoeDetailsAsync<ShoeDetailDTO, ShoeDetail>(shoe.shoeDetails, (detail) => new ShoeDetail
                {
                    Id = Guid.NewGuid(),
                    Shoe = newShoe,
                    Size = detail.Size,
                    Quantity = detail.Quantity
                });
                // Thêm hình ảnh giày
                if (shoe.AdditionalImages != null)
                {
                    for (int i = 0; i < shoe.AdditionalImages.Count; i++)
                    {
                        var imageUrl = await FileHelper.AddShoeOtherImageAsync(webHostEnvironment, newShoe.Id, shoe.AdditionalImages[i], i);
                        newShoe.OtherImages.Add(new ShoeImage { Url = imageUrl, Shoe = newShoe });
                    }

                }
                // Thêm mùa giày
                var shoeSeasons = AddShoeDetailsAsync<ShoeSeasonDTO, ShoeSeason>(shoe.Seasons, (season) => new ShoeSeason
                {
                    Season = season.Season,
                    Shoe = newShoe
                });
                // Thêm màu giày
                var shoeColors = AddShoeDetailsAsync<ShoeColorDTO, ShoeColor>(shoe.Colors, (color) => new ShoeColor
                {
                    Color = color.Color,
                    Shoe = newShoe
                });
                newShoe.shoeDetails = shoeDetails;
                newShoe.Seasons = shoeSeasons;
                newShoe.Colors = shoeColors;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new InvalidOperationException("Failed to add shoe details.", ex);
            }
        }
        private ICollection<string> UpdateShoeImages(
            ICollection<string> existingImages,
            ICollection<string> newImages,
            List<int> updateIndices)
                {
            // Sao chép danh sách ảnh hiện có
            var updatedImages = existingImages.ToList();

            // 1. Cập nhật các ảnh tại chỉ mục được chỉ định
            for (int i = 0; i < updateIndices.Count; i++)
            {
                int index = updateIndices[i];
                if (index < updatedImages.Count)
                {
                    // Thay thế ảnh tại chỉ mục tương ứng
                    updatedImages[index] = newImages.ElementAt(i);
                }
            }

            // 2. Thêm các ảnh mới vào cuối danh sách nếu còn thừa ảnh mới
            int remainingImages = newImages.Count - updateIndices.Count;
            if (remainingImages > 0)
            {
                for (int i = updateIndices.Count; i < newImages.Count; i++)
                {
                    if (updatedImages.Count < 4) // Đảm bảo không vượt quá 4 ảnh
                    {
                        updatedImages.Add(newImages.ElementAt(i));
                    }
                }
            }

            return updatedImages;
        }

        // Hàm phụ trợ để thêm chi tiết giày
        private ICollection<U> AddShoeDetailsAsync<T, U>(
            IEnumerable<T> source,
            Func<T, U> createEntity)
        {
            var entities = new List<U>();
            foreach (var item in source)
            {
                entities.Add(createEntity(item)); // Tạo thực thể từ dữ liệu đầu vào
            }
            return entities;
        }

    }

}
