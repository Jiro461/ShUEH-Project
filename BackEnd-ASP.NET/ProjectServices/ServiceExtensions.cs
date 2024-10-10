using System;
using BackEnd_ASP.NET.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;

public static class ServiceExtensions
{
    /// <summary>
    /// Đăng ký các dịch vụ (DI) cho ứng dụng.
    /// </summary>
    public static void AddProjectServices(this IServiceCollection services)
    {
        ConfigureTransientServices(services);
        ConfigureAuthentication(services);
        ConfigureDatabase(services);
        ConfigureCors(services);
        ConfigureSwagger(services);
    }

    /// <summary>
    /// Cấu hình các dịch vụ Transient.
    /// </summary>
    private static void ConfigureTransientServices(IServiceCollection services)
    {
        services.AddTransient<IEmailSender, EmailSender>();
        // Thêm các dịch vụ transient khác nếu cần
    }

    /// <summary>
    /// Cấu hình dịch vụ xác thực bằng cookie.
    /// </summary>
    private static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "ShUEHApplication-Cookies-Authentication"; // Tên của cookie
                    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP
                });
    }

    /// <summary>
    /// Cấu hình dịch vụ CORS.
    /// </summary>
    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Địa chỉ của frontend
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });
    }

    /// <summary>
    /// Cấu hình Swagger.
    /// </summary>
    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }


    /// <summary>
    /// Cấu hình EntityFramework.
    /// </summary>
    private static void ConfigureDatabase(IServiceCollection services)
    {
    }
}
