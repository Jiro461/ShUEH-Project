using System.Globalization;
using System.Text.RegularExpressions;
namespace BackEnd_ASP_NET.Utilities.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Chuyển đổi một số thập phân thành phần trăm.
        /// </summary>
        /// <param name="value">Giá trị số cần chuyển đổi.</param>
        /// <returns>Chuỗi biểu diễn phần trăm với dấu %.</returns>
        public static string ToPercentage(this double value)
        {
            return (value * 100).ToString("0.##") + "%";
        }
        // Chuyển đổi chuỗi thành định dạng Title Case
        /// <summary>
        /// Đổi chuỗi thành chuỗi mới có chữ viết đầu từng từ là chữ Hoa
        /// </summary>
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var words = Regex.Split(str, @"\s+");
            var result = words.Select(word =>
                string.IsNullOrEmpty(word)
                ? word
                : char.ToUpper(word[0]) + word.Substring(1).ToLower())
                .Aggregate((current, next) => current + " " + next);

            return result;
        }

        // Kiểm tra xem chuỗi có phải email hợp lệ không
        /// <summary>
        /// Kiểm tra xem chuỗi có phải email hợp lệ không
        /// </summary>
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

        // Kiểm tra xem chuỗi có phải số nguyên không
        /// <summary>
        /// Kiểm tra xem chuỗi có phải số nguyên không
        /// </summary>
        public static bool IsInteger(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return Regex.IsMatch(str, @"^[0-9]+$");
        }
    }

    public static class DoubleExtensions
    {
        // Chuyển đổi giá trị số thành định dạng tiền tệ VND
        /// <summary>
        /// Chuyển đổi giá trị số thành định dạng tiền tệ VND (đ)
        /// </summary>
        public static string ToVnd(this double donGia)
        {
            return donGia.ToString("#,##0") + " đ";
        }
    }

    public static class DateTimeExtensions
    {
        // Chuyển đổi ngày tháng thành chuỗi định dạng mong muốn
        /// <summary>
        /// Chuyển đổi ngày tháng thành chuỗi định dạng mong muốn
        /// </summary>
        public static string FormatDate(this DateTime date, string format = "dd/MM/yyyy")
        {
            return date.ToString(format);
        }
        /// <summary>
        /// Chuyển đổi chuỗi thành kiểu DateTime với định dạng mong muốn
        /// </summary>
        /// <returns>Giá trị DateTime nếu chuyển đổi thành công, null nếu không thành công</returns>
        public static DateTime ToDateTime(this string dateString, string format = "dd/MM/yyyy")
        {
            DateTime parsedDate;
            // Sử dụng TryParseExact để tránh ngoại lệ nếu chuỗi không đúng định dạng
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out parsedDate))
            {
                return parsedDate; // Trả về giá trị DateTime nếu chuyển đổi thành công
            }

            // Ném ra ngoại lệ nếu không thể chuyển đổi
            throw new ArgumentException($"Chuỗi '{dateString}' không thể chuyển đổi thành kiểu DateTime với định dạng '{format}'.");
        }
        
        /// <summary>
        /// Chuyển đổi từ UTC sang giờ Việt Nam (UTC+7)
        /// </summary>
        /// <returns>Thời gian ở định dạng giờ Việt Nam</returns>
        public static DateTimeOffset ConvertUtcToVietnamTime(this DateTimeOffset dateTime)
        {
            // Tính toán thời gian Việt Nam (UTC+7)
            return dateTime.AddHours(7);
        }
    }
}