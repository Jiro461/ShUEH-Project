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
            var shoesDTO = shoes.Select(shoe => new ShoeGetDTO
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Material = shoe.Material ?? string.Empty,
                Category = shoe.Category ?? string.Empty,
                ImageUrl = shoe.ImageUrl ?? string.Empty,
                Price = shoe.Price,
                IsSale = shoe.IsSale,
                Discount = shoe.Discount,
                CreatedAt = shoe.CreateDate,
                OtherImages = shoe.OtherImages == null ? null : shoe.OtherImages.Select(image => new ShoeImage
                {
                    Id = image.Id,
                    Url = image.Url
                }).ToList(),
                Seasons = shoe.Seasons == null ? null : shoe.Seasons.Select(season => new ShoeSeasonDTO
                {
                    Season = season.Season
                }).ToList(),
                Colors = shoe.Colors == null ? null : shoe.Colors.Select(color => new ShoeColorDTO
                {
                    Color = color.Color
                }).ToList(),
                shoeDetails = shoe.shoeDetails == null ? null : shoe.shoeDetails.Select(detail => new ShoeDetailDTO
                {
                    Size = detail.Size,
                    Quantity = detail.Quantity
                }).ToList(),
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14)
            });
            return Ok(shoesDTO); // Trả về danh sách giày
        }

        // Lấy giày theo ID
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id);
            if (shoe == null)
                return NotFound($"Shoe with ID {id} not found."); // Trả về NotFound nếu không tìm thấy
            var shoeDTO = new ShoeGetDTO
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Gender = shoe.Gender,
                Price = shoe.Price,
                Material = shoe.Material ?? string.Empty,
                Category = shoe.Category ?? string.Empty,
                ImageUrl = shoe.ImageUrl ?? string.Empty,
                Description = shoe.Description ?? string.Empty,
                OtherImages = shoe.OtherImages == null ? null : shoe.OtherImages.Select(image => new ShoeImage
                {
                    Id = image.Id,
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
            return Ok(shoeDTO); // Trả về giày nếu tìm thấy
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
                }).ToList(),
                Seasons = shoe.Seasons.Select(season => new ShoeSeason
                {
                    Id = Guid.NewGuid(),
                    Season = season.Season,
                    ShoeId = newShoeId
                }).ToList()
            };

            await AddShoeImageAsync(newShoe, shoe); // Thêm các chi tiết của giày
            await shoeRepository.AddShoeAsync(newShoe); // Thêm giày vào kho
            await notificationService.CreateNotificationForShoe(newShoe);
            return Ok("Shoe created successfully"); // Trả về 201 Created
        }

        // Cập nhật thông tin một đôi giày
        public async Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO updateShoe)
        {
            var existingShoe = await shoeRepository.GetShoeByIdAsync(shoeId);
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

            
            existingShoe.OtherImages = await UpdateShoeImageAsync(existingShoe, updateShoe);

            existingShoe.shoeDetails = updateShoe.shoeDetails.Select(detail => new ShoeDetail
            {
                Id = existingShoe.shoeDetails.FirstOrDefault(d => d.Size == detail.Size)?.Id ?? Guid.NewGuid(),
                Shoe = existingShoe,
                Size = detail.Size,
                Quantity = detail.Quantity
            }).ToList();
            existingShoe.Seasons = updateShoe.Seasons.Select(season => new ShoeSeason
            {
                Season = season.Season,
                Shoe = existingShoe
            }).ToList();

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
        private async Task<List<ShoeImage>> UpdateShoeImageAsync(Shoe existingShoe, ShoePostDTO updateShoe)
        {
            var newImages = updateShoe.AdditionalImages;
            var newImagesList = new List<ShoeImage>();

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
    }

}
