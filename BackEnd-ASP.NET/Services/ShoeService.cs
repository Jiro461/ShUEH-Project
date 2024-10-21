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
            var shoeDetails = shoe.shoeDetails.Select(detail => new ShoeDetail
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
                shoeDetails = shoeDetails,
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
            var existingShoe = await context.Shoes.FindAsync(shoeId);
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
            existingShoe.Colors = UpdateShoeAttributes(existingShoe.Colors, updateShoe.Colors, (color) => new ShoeColor
            {
                Color = color.Color,
                Shoe = existingShoe
            });
            existingShoe.ImageUrl = await FileHelper.UpdateShoeImageAsync(webHostEnvironment, existingShoe, updateShoe);

            // Cập nhật các hình ảnh phụ
            if (updateShoe.AdditionalImages != null && updateShoe.AdditionalImages.Count > 0)
            {
                for (int i = 0; i < updateShoe.AdditionalImages.Count; i++)
                {
                    // Cập nhật hình ảnh hiện có
                    ShoeImage? image = existingShoe.OtherImages.ElementAt(i);
                    image.Url = await FileHelper.UpdateShoeOtherImageAsync(webHostEnvironment, image, updateShoe.AdditionalImages[i], i);
                }
            }

            var updatedShoeDetails = UpdateShoeAttributes(existingShoe.shoeDetails, updateShoe.shoeDetails, (detail) => new ShoeDetail
            {
                Id = existingShoe.shoeDetails.FirstOrDefault(d => d.Size == detail.Size)?.Id ?? Guid.NewGuid(),
                Shoe = existingShoe,
                Size = detail.Size,
                Quantity = detail.Quantity
            });

            existingShoe.shoeDetails = updatedShoeDetails;
            // Xử lý các thuộc tính Colors, Seasons và Sizes
            var updatedShoeSeasons = UpdateShoeAttributes(existingShoe.Seasons, updateShoe.Seasons, (season) => new ShoeSeason
            {
                Season = season.Season,
                Shoe = existingShoe
            });
            existingShoe.Seasons = updatedShoeSeasons;

            await shoeRepository.UpdateShoeAsync(existingShoe); // Cập nhật giày trong kho
            await notificationService.CreateUpdateNotificationForEntityChange(existingShoe);
            return Ok("Shoe updated successfully"); // Trả về thông báo thành công
        }
        private void AddShoeAttributes<T, U>(
            IEnumerable<T> attributes,
            Func<T, U> createFunc,
            ICollection<U> collection)
        {
            foreach (var attribute in attributes)
            {
                collection.Add(createFunc(attribute));
            }
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

        // Hàm phụ trợ để thêm chi tiết giày
        private void AddShoeDetailsAsync<T, U>(
            IEnumerable<T> source,
            Func<T, U> createEntity)
        {
            var entities = new List<U>();
            foreach (var item in source)
            {
                entities.Add(createEntity(item)); // Tạo thực thể từ dữ liệu đầu vào
            }
        }

        // Hàm phụ trợ để thêm các chi tiết của giày
        private async Task AddShoeDetailsAsync(Shoe newShoe, ShoePostDTO shoe)
        {
            try
            {
                AddShoeDetailsAsync<ShoeDetailDTO, ShoeDetail>(shoe.shoeDetails, (detail) => new ShoeDetail
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
                AddShoeDetailsAsync<ShoeSeasonDTO, ShoeSeason>(shoe.Seasons, (season) => new ShoeSeason
                {
                    Season = season.Season,
                    Shoe = newShoe
                });


            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new InvalidOperationException("Failed to add shoe details.", ex);
            }
        }
        private ICollection<T> UpdateShoeAttributes<T, U>(ICollection<T> existingAttributes, ICollection<U> newAttributes, Func<U, T> createAttribute)
        where T : class
        {
            var newAttributesList = newAttributes.ToList();
            ICollection<T> updatedAttributes = new List<T>();
            foreach (var attr in newAttributesList)
            {
                var createdAttribute = createAttribute(attr);
                updatedAttributes.Add(createdAttribute);
            }
            return updatedAttributes;
        }
    }

}
