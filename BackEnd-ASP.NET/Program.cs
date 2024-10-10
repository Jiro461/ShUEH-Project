using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddProjectServices(builder.Configuration);


var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins"); //Sử dụng Cors

app.UseHttpsRedirection();

app.MapControllers(); // Ensure you have this if using controllers

app.Run();
