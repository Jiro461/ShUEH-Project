using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;

namespace BackEnd_ASP.NET.Services
{
    public class ShoeService : ControllerBase, IShoeService
    {
        private readonly IShoeRepository shoeRepository; // Repository để thao tác với dữ liệu giày
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;

        public ShoeService(IShoeRepository shoeRepository, ShUEHContext context, INotificationService notificationService)
        {
            this.shoeRepository = shoeRepository;
            this.context = context;
            this.notificationService = notificationService;
        }

        // Lấy tất cả giày từ kho
        public async Task<ICollection<Shoe>> GetAllShoesAsync()
        {
            var shoes = await shoeRepository.GetAllShoesAsync();
            return shoes.ToList(); // Trả về danh sách giày
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
        public async Task<IActionResult> AddShoeAsync(ShoeDTO shoe)
        {
            if (shoe == null)
                return BadRequest("Shoe data is required."); // Kiểm tra dữ liệu đầu vào
            if(!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình
            
            // Tạo một đối tượng giày mới
            var newShoe = new Shoe
            {
                Name = shoe.Name,
                Brand = shoe.Brand,
                Material = shoe.Material,
                Category = shoe.Category,
                ImageUrl = shoe.ImageUrl,
                Description = shoe.Description,
                Price = shoe.Price,
                Stock = shoe.Stock,
                IsSale = shoe.IsSale,
                Discount = shoe.Discount,
            };

            await shoeRepository.AddShoeAsync(newShoe); // Thêm giày vào kho
            await AddShoeDetailsAsync(newShoe, shoe); // Thêm các chi tiết của giày
            await notificationService.CreateNotificationForShoe(newShoe);
            return CreatedAtAction(nameof(GetShoeByIdAsync), new { id = newShoe.Id }, newShoe); // Trả về 201 Created
        }

        // Cập nhật thông tin một đôi giày
        public async Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoeDTO updateShoe)
        {
            var existingShoe = await shoeRepository.GetShoeByIdAsync(shoeId);
            if (existingShoe == null)
                return NotFound($"Shoe with ID {shoeId} not found."); // Kiểm tra giày tồn tại
            if(!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra trạng thái mô hình
            // Cập nhật thông tin giày
            existingShoe.Name = updateShoe.Name;
            existingShoe.Brand = updateShoe.Brand;
            existingShoe.Material = updateShoe.Material;
            existingShoe.Category = updateShoe.Category;
            existingShoe.ImageUrl = updateShoe.ImageUrl;
            existingShoe.Description = updateShoe.Description;
            existingShoe.Price = updateShoe.Price;
            existingShoe.Stock = updateShoe.Stock;
            existingShoe.IsSale = updateShoe.IsSale;
            existingShoe.Discount = updateShoe.Discount;
            ICollection<ShoeColor> colors = new HashSet<ShoeColor>();
            ICollection<ShoeImage> images = new HashSet<ShoeImage>();
            ICollection<ShoeSeason> seasons = new HashSet<ShoeSeason>();
            ICollection<ShoeSize> sizes = new HashSet<ShoeSize>();
            
            AddShoeAttributes(updateShoe.Colors, (color) => new ShoeColor
            {
                Color = color.Color,
                Shoe = existingShoe
            }, colors);
            
            AddShoeAttributes(updateShoe.OtherImages, (image) => new ShoeImage
            {
                Url = image.Url,
                Shoe = existingShoe
            }, images);
            
            AddShoeAttributes(updateShoe.Seasons, (season) => new ShoeSeason
            {
                Season = season.Season,
                Shoe = existingShoe
            }, seasons);
            
            AddShoeAttributes(updateShoe.Sizes, (size) => new ShoeSize
            {
                Size = size.Size,
                Shoe = existingShoe
            }, sizes);
            //Cập nhật các thuộc tính của giày có mối quan hệ 1 - nhiều
            existingShoe.Colors = colors;
            existingShoe.OtherImages = images;
            existingShoe.Seasons = seasons;
            existingShoe.Sizes = sizes;

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
        private async Task AddShoeDetailsAsync<T>(
            IEnumerable<T> source,
            Func<T, T> createEntity,
            Func<IEnumerable<T>, Task> addEntitiesAsync)
        {
            var entities = new List<T>();
            foreach (var item in source)
            {
                entities.Add(createEntity(item)); // Tạo thực thể từ dữ liệu đầu vào
            }
            await addEntitiesAsync(entities.AsEnumerable()); // Thêm các thực thể vào DB
        }

        // Hàm phụ trợ để thêm các chi tiết của giày
        private async Task AddShoeDetailsAsync(Shoe newShoe, ShoeDTO shoe)
        {
            try
            {
                // Thêm màu giày
                await AddShoeDetailsAsync<ShoeColor>(shoe.Colors, (color) => new ShoeColor
                {
                    Color = color.Color,
                    Shoe = newShoe
                }, shoeRepository.AddShoeColorAsync);

                // Thêm hình ảnh giày
                await AddShoeDetailsAsync<ShoeImage>(shoe.OtherImages, (image) => new ShoeImage
                {
                    Url = image.Url,
                    Shoe = newShoe
                }, shoeRepository.AddShoeImageAsync);

                // Thêm mùa giày
                await AddShoeDetailsAsync<ShoeSeason>(shoe.Seasons, (season) => new ShoeSeason
                {
                    Season = season.Season,
                    Shoe = newShoe
                }, shoeRepository.AddShoeSeasonAsync);

                // Thêm kích thước giày
                await AddShoeDetailsAsync<ShoeSize>(shoe.Sizes, (size) => new ShoeSize
                {
                    Size = size.Size,
                    Shoe = newShoe
                }, shoeRepository.AddShoeSizeAsync);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new InvalidOperationException("Failed to add shoe details.", ex);
            }
        }
    }

}
