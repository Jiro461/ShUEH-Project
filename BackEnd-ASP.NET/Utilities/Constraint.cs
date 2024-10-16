using System.Globalization;
using System.Text.RegularExpressions;
namespace BackEnd_ASP_NET.Utilities.Extensions
{
    public static class MyDateTime
    {
        public static DateTimeOffset VietNam = DateTimeOffset.UtcNow.AddHours(7);
    }
}