using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;

namespace BackEnd_ASP.NET.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoeController : ControllerBase
    {
        // Danh sách các thương hiệu giày hợp lệ để kiểm tra
        private readonly string[] brands = { "NIKE", "ADIDAS", "PUMA", "REEBOK", "CONVERSE" };
        
        // Danh sách các mẫu giày nổi bật trên trang chủ
        private readonly string[] homeShoe = { "Nike Youth React Presto Extreme", "Nike Air Max 270", "Nike Downshifter 13" };
        
        // Tiêm các service vào controller để có thể sử dụng các phương thức từ IShoeService, context (DB Context) và repository
        private readonly IShoeService shoeService;
        private readonly ShUEHContext context;
        private readonly IShoeRepository shoeRepository;

        // Constructor để khởi tạo các service và context
        public ShoeController(IShoeService shoeService, ShUEHContext context, IShoeRepository shoeRepository)
        {
            this.shoeService = shoeService;
            this.context = context;
            this.shoeRepository = shoeRepository;
        }

        #region SimpleAPI
        // API này trả về số lượng giày theo từng thương hiệu trong hệ thống
        [HttpGet("count-brand")]
        public async Task<IActionResult> GetCountBrandShoe()
        {
            // Group các giày theo thương hiệu và đếm số lượng mỗi thương hiệu
            var brands = await context.Shoes.GroupBy(s => s.Brand).Select(g => new { Brand = g.Key, Count = g.Count() }).ToListAsync();
            return Ok(brands); // Trả về kết quả dưới dạng OkObjectResult
        }

        // API lấy danh sách giày theo thương hiệu. Thương hiệu phải hợp lệ trong danh sách 'brands'.
        [HttpGet("brand")]
        public async Task<IActionResult> GetShoeByBrand(string brand)
        {
            // Kiểm tra nếu thương hiệu không hợp lệ, trả về lỗi 404
            if (!brands.Contains(brand.ToUpper())) return NotFound("Invalid brand");
            
            // Lấy userId từ claim trong JWT token nếu có, dùng để tùy chỉnh dữ liệu trả về cho user (ví dụ: lịch sử mua hàng)
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Truy vấn giày theo thương hiệu từ cơ sở dữ liệu và sắp xếp theo ngày tạo giảm dần
            var shoes = await context.Shoes
                .Where(s => s.Brand == brand)
                .OrderByDescending(s => s.CreateDate)
                .ToListAsync();

            // Chuyển đổi giày thành DTO để trả về cho người dùng
            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTOForAdmin(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO); // Trả về dữ liệu giày cho admin hoặc người dùng
        }

        // API lấy ra n giày mới nhất từ cơ sở dữ liệu
        [HttpGet("newest/{number}")]
        public async Task<IActionResult> GetNewestShoe(int number)
        {
            // Lấy userId từ claim của token
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Truy vấn các giày mới nhất, sắp xếp theo ngày tạo giảm dần và lấy số lượng n
            var shoes = await context.Shoes
                .OrderByDescending(s => s.CreateDate)
                    .Take(number) // Lấy số lượng giày mới nhất
                    .ToListAsync();

            // Chuyển đổi giày thành DTO và trả về cho người dùng
            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTOForUser(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        // API trả về tổng số giày trong hệ thống
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalShoe()
        {
            // Đếm tổng số giày trong cơ sở dữ liệu và trả về kết quả
            var totalShoe = await context.Shoes.CountAsync();
            return Ok(totalShoe); // Trả về số lượng giày
        }

        // API lấy các giày trên trang chủ (giày nổi bật)
        [HttpGet("home")]
        public async Task<IActionResult> GetHomeShoe()
        {
            // Lấy userId từ claim trong JWT token để tùy chỉnh dữ liệu cho user
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Lọc ra giày có tên thuộc danh sách homeShoe
            var shoes = await context.Shoes
                            .Where(shoe => homeShoe.Contains(shoe.Name))
                            .ToListAsync();

            // Chuyển giày thành DTO với thông tin cơ bản
            var shoesDTO = shoes.Select(shoe => new
            {
                Name = shoe.Name,
                Gender = shoe.Gender,
                Brand = shoe.Brand,
                Discount = shoe.Discount,
                Description = shoe.Description,
                ImageUrl = shoe.ImageUrl,
                Price = shoe.Price,
                Id = shoe.Id
            }).OrderByDescending(g => g.Gender); // Sắp xếp theo giới tính
            return Ok(shoesDTO); // Trả về danh sách giày cho người dùng
        }

        // API xóa một giày theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoe(Guid id)
        {
            // Gọi service để xóa giày và trả về kết quả
            return await shoeService.DeleteShoeAsync(id);
        }

        // API lấy n giày bán chạy nhất
        [HttpGet("most-sold/{number}")]
        public async Task<IActionResult> GetMostSoldShoe(int number)
        {
            // Lấy userId từ claim trong JWT token
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Truy vấn các giày bán chạy nhất, sắp xếp theo số lượng đã bán và lấy n giày
            var shoes = await context.Shoes
                .OrderByDescending(s => s.Sold)
                .Take(number)
                .ToListAsync();

            // Chuyển đổi giày thành DTO và trả về cho người dùng
            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTOForUser(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        // API tìm giày hợp tác giữa Nike và Satan
        [HttpGet("collaboration")]
        public async Task<IActionResult> GetCollaborationShoe()
        {
            // Lấy userId từ claim của token
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Truy vấn giày hợp tác giữa Nike và Satan
            var shoe = await context.Shoes
                .FirstOrDefaultAsync(s => s.Name == "Satan" && s.Brand == "Nike");

            // Kiểm tra nếu không tìm thấy giày hợp tác thì trả về lỗi 404
            if (shoe == null) return NotFound("No collaboration shoe found.");
            
            // Chuyển đổi giày thành DTO và trả về cho người dùng
            var shoeDTO = shoeService.ConvertShoeToShoeGetDTO(shoe, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoeDTO);
        }
        #endregion

        #region ComplexAPI
        // API lấy tất cả giày cho người dùng (có phân quyền tùy theo user)
        [HttpGet("all")]
        public async Task<IActionResult> GetAllShoes()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            // Nếu người dùng không đăng nhập, lấy tất cả giày, ngược lại lấy giày theo userId
            var shoes = userId == null
                ? await shoeService.GetAllShoesAsync()
                : await shoeService.GetAllShoesAsync(Guid.Parse(userId));
                
            if (shoes == null) return NotFound("Not Found Any Shoe");
            return Ok(shoes); // Trả về tất cả giày
        }

        // API lấy các giày tương tự một giày theo ID
        [HttpGet("similar/{shoeId}")]
        public async Task<IActionResult> GetSimilarShoes(Guid shoeId)
        {
            // Gọi service để lấy các giày tương tự theo ID giày
            return Ok(await shoeService.GetSimilarShoes(shoeId));
        }

        // API lấy tất cả giày cho admin (bao gồm thông tin chi tiết về size, mùa, màu sắc, hình ảnh khác, và bình luận)
        [HttpGet("admin/all")]
        public async Task<IActionResult> GetAllShoesAdminAsync()
        {
            // Lấy tất cả giày cho admin, bao gồm các thông tin chi tiết liên quan
            var shoes = await context.Shoes.Include(shoe => shoe.shoeDetails.OrderBy(detail => detail.Size))
                                            .Include(shoe => shoe.Seasons)
                                            .Include(shoe => shoe.Colors)
                                            .Include(shoe => shoe.OtherImages)
                                            .Include(shoe => shoe.Comments)
                                            .ToListAsync();
            // Chuyển đổi giày thành DTO để trả về
            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTOForAdmin(shoes);
            return Ok(shoesDTO);
        }

        // API lấy tất cả giày với phân trang (dựa trên page và pageSize)
        [HttpGet("all/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllShoesAsync(int page, int pageSize)
        {
            // Kiểm tra tính hợp lệ của page và pageSize
            if (page < 0 || pageSize < 0) return BadRequest("Invalid page or page size");
            
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var totalShoes = await context.Shoes.CountAsync(); // Lấy tổng số giày
            
            // Truy vấn các giày với phân trang (page, pageSize)
            var shoes = userId == null
                ? await shoeService.GetAllShoesAsync(page: page, pageSize: pageSize)
                : await shoeService.GetAllShoesAsync(Guid.Parse(userId), page: page, pageSize: pageSize);
                
            if (shoes == null) return NotFound("Not Found Any Shoe");

            // Tính toán tổng số trang và trả về dữ liệu phân trang
            var response = new
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalShoes / pageSize),
                Data = shoes
            };
            return Ok(response); // Trả về dữ liệu phân trang
        }

        // API lấy giày theo ID (dành cho người dùng)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await shoeService.GetShoeByIdFromUserAsync(id, userId != null ? Guid.Parse(userId) : null);
        }

        // API lấy giày theo ID (dành cho admin)
        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetShoeByIdFromAdminAsync(Guid id)
        {
            // Kiểm tra nếu user có role Admin mới cho phép
            var IsAdmin = HttpContext.User.IsInRole("Admin");
            if (!IsAdmin) return Unauthorized();
            
            return await shoeService.GetShoeByIdFromAdminAsync(id);
        }

        // API tạo một giày mới từ dữ liệu gửi lên
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ShoePostDTO shoe)
        {
            try
            {
                // Gọi service để thêm giày mới vào cơ sở dữ liệu
                return await shoeService.AddShoeAsync(shoe);
            }
            catch
            {
                // Nếu có lỗi trong quá trình thêm, trả về lỗi 500
                return StatusCode(500, "Internal server error");
            }
        }

        // API cập nhật giày theo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoeById(Guid id, [FromForm] ShoePostDTO shoe)
        {
            // Gọi service để cập nhật thông tin giày
            return await shoeService.UpdateShoeAsync(id, shoe);
        }
        #endregion
    }
}
