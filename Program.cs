using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data;
using MiPrimerAppMVC.Data.Repository;
using MiPrimerAppMVC.Data.Repository.Interfaces;
using MiPrimerAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);


//----------------------------------------
// Obtener cadena de conexión del archivo de configuración
var connectionString = builder.Configuration.GetConnectionString("ProductosContext");

// Registrar el DbContext con SQL Server
builder.Services.AddDbContext<ProductosContext>(options =>
    options.UseSqlServer(connectionString));

    builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

//----------------------------------------


// Add services to the container.
builder.Services.AddControllersWithViews();

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
