using System.Security.Cryptography;
using System.Text;
namespace BackEnd_ASP_NET.Utilities.Security
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Chuyển đổi một chuỗi thành dạng băm MD5.
        /// </summary>
        /// <returns>Chuỗi băm MD5 dưới dạng chuỗi ký tự thập lục phân.</returns>
        public static string ToMD5(this string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in bHash)
                {
                    sbHash.Append(b.ToString("x2")); // Chuyển từng byte thành chuỗi thập lục phân
                }
                return sbHash.ToString();
            }
        }
        /// <summary>
        /// Chuyển đổi một chuỗi thành dạng băm SHA-256.
        /// </summary>
        /// <returns>Chuỗi băm SHA-256 dưới dạng chuỗi ký tự thập lục phân.</returns>
        public static string ToSHA256(this string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in bHash)
                {
                    sbHash.Append(b.ToString("x2")); // Chuyển từng byte thành chuỗi thập lục phân
                }
                return sbHash.ToString();
            }
        }
    }
}
