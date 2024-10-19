using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddProjectServices(builder.Configuration);


var app = builder.Build();


app.UseStaticFiles();
// app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication(); // Phải có để sử dụng xác thực
app.UseAuthorization();
// Ensure you have this if using controllers
app.MapControllers();

app.Run();
