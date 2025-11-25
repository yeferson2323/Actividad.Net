using Microsoft.EntityFrameworkCore;
using RoarMot.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Con esto conectamos a base de datos 
var conString = builder.Configuration.GetConnectionString("conexion") ??
    throw new InvalidOperationException("Error cadena de conexión'" + " not found.");

builder.Services.AddDbContext<MymotoContext>(option =>
    option.UseMySql(conString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-maradb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
