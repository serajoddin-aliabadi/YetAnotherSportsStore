using Microsoft.EntityFrameworkCore;
using SportsStore.Web.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("SportsStoreConnection"));
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();


var app = builder.Build();


app.UseStaticFiles();

app.MapControllerRoute("pagination",
	"Products/Page{productPage}",
	new { Controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();


SeedData.EnsurePopulated(app);


app.Run();
