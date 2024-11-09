// SeedData.cs
using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static async Task Seed(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ShUEHContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
            List<Guid> shoeIds = context.Shoes.Select(s => s.Id).ToList();
            var seeder = new DatabaseSeeder(context, userManager, notificationService);
            ShUEHContext.IsSeeding = true;
            // Gọi phương thức SeedData trong seeder
            await seeder.SeedData(shoeIds);
            ShUEHContext.IsSeeding = false;
            Console.WriteLine("Seed Data Success");
        }
    }
}
