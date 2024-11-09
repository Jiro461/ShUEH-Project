using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP.NET.Services.VnPay;
using BackEnd_ASP_NET;
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
        //ConfigureCors(services); 
        services.AddControllers();
        ConfigureMemoryCache(services);
        ConfigureHttpService(services);
        ConfigureTransientServices(services);
        ConfigureSingletonServices(services);
        ConfigureScopedServices(services);
        ConfigureAuthentication(services);
        ConfigureEntityFramework(services, configuration);
        ConfigureSwagger(services);
        ConfigureSessionService(services);
        services.AddSignalR();
    }
    private static void ConfigureHttpService(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddHttpContextAccessor();
    }
    /// <summary>
    /// Cấu hình dịch vụ Session
    /// </summary>
    private static void ConfigureSessionService(IServiceCollection services)
    {
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromDays(1); // Set session timeout
            options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });
    }
    /// <summary>
    /// Cấu hình các dịch vụ Cache
    /// </summary>
    private static void ConfigureMemoryCache(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddDistributedMemoryCache();
    }
    private static void ConfigureSingletonServices(IServiceCollection services)
    {
        services.AddSingleton<IVnPayService, VnPayService>();
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
        // Các dịch vụ Scoped được tạo mới cho mỗi request
        /*Repository*/
        services.AddScoped<IOrderRepository, OrderRepository>();  // Repository cho đơn hàng
        services.AddScoped<IUserRepository, UserRepository>();  // Repository cho người dùng
        services.AddScoped<IShoeRepository, ShoeRepository>();  // Repository cho giày
        services.AddScoped<IWishListRepository, WishListRepository>();  // Repository cho danh sách yêu thích
        services.AddScoped<ICommentRepository, CommentRepository>();  // Repository cho bình luận
        services.AddScoped<IStatisticRepository, StatisticRepository>();  // Repository cho thống kê
        services.AddScoped<IDiscountRepository, DiscountRepository>();  // Repository cho giảm giá
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();  // Repository cho tin nhắn chat

        /*Services*/
        services.AddScoped<IOrderService, OrderService>();  // Dịch vụ xử lý đơn hàng
        services.AddScoped<ICommentService, CommentService>();  // Dịch vụ xử lý bình luận
        services.AddScoped<IWishListService, WishListService>();  // Dịch vụ xử lý danh sách yêu thích
        services.AddScoped<IAccountService, AccountService>();  // Dịch vụ quản lý tài khoản
        services.AddScoped<INotificationService, NotificationService>();  // Dịch vụ thông báo
        services.AddScoped<IShoeService, ShoeService>();  // Dịch vụ xử lý giày
        services.AddScoped<IPaymentService, PaymentService>();  // Dịch vụ thanh toán
        services.AddScoped<IDiscountService, DiscountService>();  // Dịch vụ giảm giá
        services.AddScoped<ChatHubServices>();  // Dịch vụ Hub cho SignalR chat

        /*Identity*/
        services.AddScoped<UserManager<User>>();  // Quản lý người dùng trong hệ thống
        services.AddScoped<SignInManager<User>>();  // Quản lý đăng nhập người dùng
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
            options.Cookie.IsEssential = true; // Đảm bảo cookie được gửi ngay cả khi người dùng chưa đồng ý
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
