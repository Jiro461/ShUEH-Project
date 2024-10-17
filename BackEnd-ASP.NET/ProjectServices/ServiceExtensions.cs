using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions
{
    /// <summary>
    /// Đăng ký các dịch vụ (DI) cho ứng dụng.
    /// </summary>
    public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureCors(services);
        services.AddControllers();//AddJsonOptions(options =>
        //     {
        //         options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        //     }); ;
        ConfigureTransientServices(services);
        ConfigureScopedServices(services);
        ConfigureAuthentication(services);
        ConfigureEntityFramework(services, configuration);
        ConfigureSwagger(services);
        services.AddHttpContextAccessor();
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
    /// Cấu hình các dịch vụ Scoped.
    /// </summary>
    private static void ConfigureScopedServices(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<SignInManager<User>>();
        services.AddScoped<INotificationService, NotificationService>();


    }
    /// <summary>
    /// Cấu hình dịch vụ xác thực bằng cookie.
    /// </summary>
    private static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Đặt DefaultSignInScheme
        })
        .AddCookie(options =>
        {
            options.Cookie.Name = "ShUEHApplication-Cookies-Authentication"; // Tên của cookie
            options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP
        }).AddGoogle(options =>
        {
            options.ClientId = "11161045560-r08im8g3rll7ifg200tgmc8gmpa1am1t.apps.googleusercontent.com";  // Thay bằng Client ID của bạn
            options.ClientSecret = "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";  // Thay bằng Client Secret của bạn
            options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
            options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
        });

    }

    /// <summary>
    /// Cấu hình dịch vụ CORS.
    /// </summary>
    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder =>
                {

                    builder.WithOrigins("http://localhost:5118", "http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    // Allow localhost origins
                    // builder.WithOrigins("http://localhost:3000", "http://localhost:5118") // Liệt kê các origin cụ thể
                    //     .AllowAnyHeader()
                    //     .AllowAnyMethod()
                    //     .AllowCredentials();
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
    private static void ConfigureEntityFramework(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShUEHContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ShUEH-DB"));
        });

        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        })
           .AddEntityFrameworkStores<ShUEHContext>().AddDefaultTokenProviders();
    }
}
