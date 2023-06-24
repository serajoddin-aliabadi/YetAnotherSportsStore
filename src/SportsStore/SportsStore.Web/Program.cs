using Microsoft.EntityFrameworkCore;
using SportsStore.Web.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(SessionCart.GetCart);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<StoreDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("SportsStoreConnection"));
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();


var app = builder.Build();


app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage",
	"{category}/Page{productPage:int}",
	new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
	new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
	new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
	"Products/Page{productPage}",
	new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();


SeedData.EnsurePopulated(app);


app.Run();
