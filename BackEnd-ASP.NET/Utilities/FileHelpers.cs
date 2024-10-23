using System;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
namespace BackEnd_ASP_NET.Utilities.FileHelpers
{
    public static class FileHelper
    {

        private static readonly List<string> AllowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".svg" };
        private static readonly List<string> AllowedMimeTypes = new List<string> { "image/jpeg", "image/png", "image/webp", "image/svg+xml" };
        public static async Task<string> UpdateAvatarAsync(
           IWebHostEnvironment webHostEnvironment,
           User user,
           UserPutDTO userDto)
        {
            // Kiểm tra xem người dùng có upload file ảnh mới không
            if (userDto.Avatar == null || userDto.Avatar.Length == 0)
            {
                return user.AvatarUrl ?? "images/avatars/noavatar.png";
            }
            var mimeType = userDto.Avatar.ContentType;
            var extension = Path.GetExtension(userDto.Avatar.FileName).ToLower();

            // Kiểm tra loại MIME và phần mở rộng hợp lệ
            if (!AllowedMimeTypes.Contains(mimeType) || !AllowedExtensions.Contains(extension))
            {
                return user.AvatarUrl ?? "images/avatars/noavatar.png";
            }

            // Đường dẫn thư mục để lưu avatar (wwwroot/images/avatars/)
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "images", "avatars");

            // Đảm bảo thư mục tồn tại (nếu chưa có thì tạo mới)
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Tạo đường dẫn file với tên là {id_user}.jpg
            var fileName = $"user_{user.Id}{Path.GetExtension(userDto.Avatar.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Lưu file mới và ghi đè nếu file đã tồn tại
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await userDto.Avatar.CopyToAsync(stream);
            }

            // Trả về đường dẫn tương đối của ảnh để lưu vào database
            return Path.Combine("images", "avatars", fileName).Replace("\\", "/");
        }
        //Update shoe image from User
        public static async Task<string> UpdateShoeImageAsync(
           IWebHostEnvironment webHostEnvironment,
           Shoe shoe,
           ShoePostDTO shoeDto)
        {
            // Kiểm tra xem người dùng có upload file ảnh mới không
            if (shoeDto.MainImage == null || shoeDto.MainImage.Length == 0)
            {
                return shoe.ImageUrl ?? "images/shoes/noimage.webp"; // Nếu không có file mới, giữ nguyên ảnh hiện tại hoặc dùng ảnh mặc định
            }
            var mimeType = shoeDto.MainImage.ContentType;
            var extension = Path.GetExtension(shoeDto.MainImage.FileName).ToLower();

            // Kiểm tra loại MIME và phần mở rộng hợp lệ
            if (!AllowedMimeTypes.Contains(mimeType) || !AllowedExtensions.Contains(extension))
            {
                return shoe.ImageUrl ?? "images/shoes/noimage.webp"; // Nếu không có file mới, giữ nguyên ảnh hiện tại hoặc dùng ảnh mặc định
            }

            // Đường dẫn thư mục để lưu ảnh (wwwroot/images/shoes/)
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "images", "shoes");

            // Đảm bảo thư mục tồn tại (nếu chưa có thì tạo mới)
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            // Tạo đường dẫn file với tên là {id_shoe}.jpg
            var fileName = $"{shoe.Id}_AnhChinh{Path.GetExtension(shoeDto.MainImage.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Lưu file mới và ghi đè nếu file đã tồn tại
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await shoeDto.MainImage.CopyToAsync(stream);
            }

            // Trả về đường dẫn tương đối của ảnh để lưu vào database
            return Path.Combine("images", "shoes", fileName).Replace("\\", "/");
        }
        //Add shoe image from Admin
        public static async Task<string> AddShoeImageAsync(
           IWebHostEnvironment webHostEnvironment,
           Guid shoeId,
           ShoePostDTO shoeDto)
        {
            // Kiểm tra xem người dùng có upload file ảnh mới không
            if (shoeDto.MainImage == null || shoeDto.MainImage.Length == 0)
            {
                return "images/shoes/noimage.webp"; // Nếu không có file mới, dùng ảnh mặc định
            }
            var mimeType = shoeDto.MainImage.ContentType;
            var extension = Path.GetExtension(shoeDto.MainImage.FileName).ToLower();

            // Kiểm tra loại MIME và phần mở rộng hợp lệ
            if (!AllowedMimeTypes.Contains(mimeType) || !AllowedExtensions.Contains(extension))
            {
                return "images/shoes/noimage.webp"; // Nếu không có file mới, dùng ảnh mặc định 
            }

            // Đường dẫn thư mục để lưu ảnh (wwwroot/images/shoes/)
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "images", "shoes");

            // Đảm bảo thư mục tồn tại (nếu chưa có thì tạo mới)
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            // Tạo đường dẫn file với tên là {id_shoe}.jpg
            var fileName = $"{shoeId}_AnhChinh{Path.GetExtension(shoeDto.MainImage.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Lưu file mới và ghi đè nếu file đã tồn tại
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await shoeDto.MainImage.CopyToAsync(stream);
            }

            // Trả về đường dẫn tương đối của ảnh để lưu vào database
            return Path.Combine("images", "shoes", fileName).Replace("\\", "/");
        }
        //Update shoe other image from Admin
        public static async Task<string> UpdateShoeOtherImageAsync(
           IWebHostEnvironment webHostEnvironment,
           ShoeImage image,
           IFormFile? newImage, int index)
        {
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "images", "shoes");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (newImage == null || newImage.Length == 0)
            {
                return image.Url ?? "images/shoes/noimage.webp"; // Nếu không có file mới, giữ nguyên ảnh hiện tại hoặc dùng ảnh mặc định
            }
            var mimeType = newImage.ContentType;
            var extension = Path.GetExtension(newImage.FileName).ToLower();
            if (!AllowedMimeTypes.Contains(mimeType) || !AllowedExtensions.Contains(extension))
            {
                return image.Url ?? "images/shoes/noimage.webp"; // Nếu file không hợp lệ, giữ nguyên ảnh hiện tại hoặc dùng ảnh mặc định
            }
            var fileName = $"{image.ShoeId}_AnhPhu_{index}{Path.GetExtension(newImage.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newImage.CopyToAsync(stream);
            }
            // Trả về đường dẫn tương đối của ảnh để lưu vào database
            return Path.Combine("images", "shoes", fileName).Replace("\\", "/");
        }
        //Add shoe other image from Admin
        public static async Task<string> AddShoeOtherImageAsync(
           IWebHostEnvironment webHostEnvironment,
           Guid shoeId,
           IFormFile? image, int index)
        {
            // Đường dẫn thư mục để lưu ảnh (wwwroot/images/shoes/)
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "images", "shoes");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (image == null || image.Length == 0)
            {
                return "images/shoes/noimage.webp"; // Nếu không có file mới, dùng ảnh mặc định
            }
            var mimeType = image.ContentType;
            var extension = Path.GetExtension(image.FileName).ToLower();

            // Kiểm tra loại MIME và phần mở rộng hợp lệ
            if (!AllowedMimeTypes.Contains(mimeType) || !AllowedExtensions.Contains(extension))
            {
                return "images/shoes/noimage.webp"; // Nếu không có file mới, dùng ảnh mặc định
            }
    

            // Đường dẫn thư mục để lưu ảnh (wwwroot/images/shoes/)
            var fileName = $"{shoeId}_AnhPhu_{index}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            // Trả về đường dẫn tương đối của ảnh để lưu vào database
            return Path.Combine("images", "shoes", fileName).Replace("\\", "/");
        }
    }
}
