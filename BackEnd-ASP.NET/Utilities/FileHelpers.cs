using System;
using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
namespace BackEnd_ASP_NET.Utilities.FileHelpers
{
    public static class FileHelper
    {

         public static async Task SaveFileFromUrlAsync(string url, Stream stream)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                await response.Content.CopyToAsync(stream);
            }
        }

        public static async Task<string> UpdateAvatarAsync(
        IWebHostEnvironment webHostEnvironment,
            User user,
            UserDTO userDto)
        {
            if (!string.IsNullOrEmpty(userDto.AvatarUrl) && userDto.AvatarUrl != user.AvatarUrl)
            {
                // Đường dẫn đến thư mục chứa ảnh
                var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images", "avatars");
                var oldAvatarPath = Path.Combine(uploads, user.AvatarUrl ?? "noavatar.png"); // Đường dẫn ảnh cũ

                // Xóa ảnh cũ nếu không phải là ảnh mặc định
                if (user.AvatarUrl != "noavatar.png" && File.Exists(oldAvatarPath))
                {
                    File.Delete(oldAvatarPath);
                }

                // Lưu ảnh mới
                var newAvatarPath = Path.Combine(uploads, $"{user.Id}");
                using (var stream = new FileStream(newAvatarPath, FileMode.Create))
                {
                    await SaveFileFromUrlAsync(userDto.AvatarUrl, stream);
                }

                // Cập nhật AvatarUrl mới trong user
                return $"images/avatars/{user.Id}";
            }

            return user.AvatarUrl; // Trả về AvatarUrl cũ nếu không cập nhật
        }
    }
}
