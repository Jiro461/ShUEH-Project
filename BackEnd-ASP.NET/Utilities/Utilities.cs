using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BackEnd_ASP_NET.Utilities
{
    public static class Utilities
    {
        // Phương thức mở rộng để chuyển đổi giá trị double thành định dạng tiền tệ VND
        public static string ToVnd(this double donGia)
        {
            return donGia.ToString("#,##0") + " đ";
        }

        // Phương thức mở rộng để chuyển đổi chuỗi thành Title Case
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            // Sử dụng Regex để tách các từ và viết hoa ký tự đầu tiên của mỗi từ
            var words = Regex.Split(str, @"\s+");
            var result = words.Select(word =>
                string.IsNullOrEmpty(word)
                ? word
                : char.ToUpper(word[0]) + word.Substring(1).ToLower())
                .Aggregate((current, next) => current + " " + next);

            return result;
        }
        public static string ToMD5(this string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in bHash)
                {
                    sbHash.Append(b.ToString("x2")); // Chuyển byte thành chuỗi hex
                }
                return sbHash.ToString();
            }
        }
        public static bool IsValidEmail(this string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Phương thức để tạo thư mục nếu chưa tồn tại
        public static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        // Phương thức để kiểm tra chuỗi có phải là số nguyên không

        public static bool IsInteger(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return Regex.IsMatch(str, @"^[0-9]+$");
        }

        public static async Task<string?> UploadFile(IFormFile file, string directory, string newName = null)
        {
            try
            {
                // Nếu newName không được cung cấp, sử dụng tên tệp gốc
                if (newName == null)
                {
                    newName = file.FileName;
                }
                // Xác định đường dẫn để lưu tệp
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", directory);
                CreateIfMissing(path); // Tạo thư mục nếu nó không tồn tại
                // Đường dẫn đầy đủ của tệp sẽ được lưu vào
                string filePath = Path.Combine(path, newName);
                // Các loại tệp được hỗ trợ
                var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
                var fileExt = Path.GetExtension(file.FileName).Substring(1).ToLower(); // Lấy phần mở rộng của tệp
                // Kiểm tra xem phần mở rộng của tệp có nằm trong danh sách các loại tệp hỗ trợ không
                if (!supportedTypes.Contains(fileExt))
                {
                    return null; // Nếu không hỗ trợ loại tệp, trả về null
                }

                // Lưu tệp vào thư mục chỉ định
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream); // Sao chép nội dung tệp vào FileStream một cách bất đồng bộ
                }
                // Trả về tên tệp mới (hoặc tên gốc nếu không thay đổi)
                return newName;
            }
            catch
            {
                return null; // Nếu có lỗi, trả về null
            }
        }
        // Chuyển đổi ngày tháng thành chuỗi định dạng mong muốn
        public static string FormatDate(DateTime date, string format = "dd/MM/yyyy")
        {
            return date.ToString(format);
        }
        public static DateTime ToDateTime(this string dateStr)
        {
            return DateTime.ParseExact(dateStr, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
