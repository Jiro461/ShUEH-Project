using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            }); ;
        ConfigureTransientServices(services);
        ConfigureScopedServices(services);
        ConfigureAuthentication(services);
        ConfigureEntityFramework(services, configuration);
        ConfigureCors(services);
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
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<SignInManager<User>>();

    }
    /// <summary>
    /// Cấu hình dịch vụ xác thực bằng cookie.
    /// </summary>
    private static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
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
