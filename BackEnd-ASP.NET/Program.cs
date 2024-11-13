using System.Text;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Middleware;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

if (args.Contains("seed"))
{
    await SeedData.Seed(app.Services);
    Console.WriteLine("Data seeding completed.");

    return;
    System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");
    Environment.Exit(0); // Kết thúc tiến trình ứng dụng
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseHttpsRedirection();
Console.WriteLine($"Current Environment: {app.Environment.EnvironmentName}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseCors("CorsPolicy");
//app.UseCors(x => x.AllowAnyMethod()
//                  .SetIsOriginAllowed(origin => true) // allow any origin
//                  .AllowAnyHeader()
//                  .AllowCredentials()                 // allow credentials

//            ); 

app.MapHub<ChatHubServices>("/chatHub");
app.UseSession();
//app.UseCors("CorsPolicy");
app.UseAuthentication(); // Phải có để sử dụng xác thực
app.UseAuthorization();
// Ensure you have this if using controllers
app.UseMiddleware<ProductViewMiddleware>();
app.UseMiddleware<SiteViewMiddleware>();
app.MapControllers();

app.Run();
