using System.Text;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddProjectServices(builder.Configuration);


builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
            options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });

var app = builder.Build();


app.UseStaticFiles();
// app.UseHttpsRedirection();
Console.WriteLine($"Current Environment: {app.Environment.EnvironmentName}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSession();
app.UseMiddleware<ProductViewMiddleware>();
app.UseRouting();
app.UseCors(x => x.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true) // allow any origin
                  .AllowCredentials()                 // allow credentials

            ); 
//app.UseCors("CorsPolicy");
app.UseAuthentication(); // Phải có để sử dụng xác thực
app.UseAuthorization();
// Ensure you have this if using controllers
app.MapControllers();

app.Run();
