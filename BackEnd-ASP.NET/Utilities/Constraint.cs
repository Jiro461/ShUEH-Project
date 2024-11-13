using System.Globalization;
using System.Text.RegularExpressions;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP_NET.Utilities.Extensions
{
    // Lớp tĩnh MyDateTime để lưu trữ thông tin thời gian
    public static class MyDateTime
    {
        // Biến tĩnh VietNam để lưu trữ thời gian hiện tại của Việt Nam
        public static DateTimeOffset VietNam = DateTimeOffset.UtcNow.AddHours(7);
    }

    // Lớp tĩnh MyURL để lưu trữ các URL cần thiết
    public static class MyURL
    {
        // URL của máy chủ
        public static string Host = "https://shueh.somee.com";
        // URL của client
        public static string ClientURL = "https://shueh7.vercel.app";
    }

    // Lớp tĩnh PaymentType để lưu trữ các loại thanh toán
    public static class PaymentType
    {
        // Hằng số cho loại thanh toán VNPAY
        public const string VNPAY = "VnPay";
        // Hằng số cho loại thanh toán COD (Cash on Delivery)
        public const string COD = "COD";
    }
}