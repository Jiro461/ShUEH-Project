using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddProjectServices(builder.Configuration);


var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseStaticFiles();
// app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); // Phải có để sử dụng xác thực
app.UseAuthorization();
// Ensure you have this if using controllers
app.MapControllers();

app.Run();
