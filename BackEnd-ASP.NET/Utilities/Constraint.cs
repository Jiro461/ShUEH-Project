using System.Globalization;
using System.Text.RegularExpressions;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;
namespace BackEnd_ASP_NET.Utilities.Extensions
{
    public static class MyDateTime
    {
        public static DateTimeOffset VietNam = DateTimeOffset.UtcNow.AddHours(7);
    }

    public static class MyURL
    {
        public static string Host = "http://localhost:5118";
        public static string ClientURL = "http://localhost:3000";
    }

}