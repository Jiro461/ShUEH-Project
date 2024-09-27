using System;
namespace BackEnd_ASP_NET.Utilities.FileHelpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Tạo thư mục nếu chưa tồn tại.
        /// </summary>
        public static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Tải tệp lên thư mục được chỉ định một cách bất đồng bộ.
        /// </summary>
        /// <returns>Tên tệp đã tải lên, hoặc null nếu quá trình tải lên thất bại.</returns>
        public static async Task<string?> UploadFile(IFormFile file, string directory, string? newName = null)
        {
            try
            {
                // Nếu không có tên mới, sử dụng tên gốc của tệp
                if (newName == null)
                {
                    newName = file.FileName;
                }

                // Xác định đường dẫn để lưu tệp
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", directory);
                CreateIfMissing(path); // Tạo thư mục nếu chưa tồn tại

                // Đường dẫn đầy đủ của tệp sẽ được lưu vào
                string filePath = Path.Combine(path, newName);

                // Các loại tệp được hỗ trợ
                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = Path.GetExtension(file.FileName).Substring(1).ToLower(); // Lấy phần mở rộng của tệp

                // Kiểm tra xem loại tệp có được hỗ trợ hay không
                if (!supportedTypes.Contains(fileExt))
                {
                    return null; // Nếu loại tệp không hỗ trợ, trả về null
                }

                // Lưu tệp vào thư mục chỉ định
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream); // Sao chép nội dung tệp vào stream
                }

                // Trả về tên tệp đã tải lên
                return newName;
            }
            catch
            {
                return null; // Nếu có lỗi xảy ra, trả về null
            }
        }
    }
}
