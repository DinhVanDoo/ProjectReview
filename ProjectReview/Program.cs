using ProjectReview.Interfaces;
using ProjectReview.Models;
using ProjectReview.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký các dịch vụ ở đây
builder.Services.AddScoped<PROJECTREVIEWContext>(); // Đăng ký DbContext
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>)); // Đăng ký IRepository và RepositoryBase
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();