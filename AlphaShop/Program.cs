using AlphaShop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HahaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PBL3") ?? throw new InvalidOperationException("Connection string 'PBL3' not found.")));
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

//app.MapControllerRoute(
//    name: "category",
//    pattern: "category",
//    defaults: new { controller = "GuestMenu", action = "Category" });

//app.MapControllerRoute(
//    name: "order",
//    pattern: "order",
//    defaults: new { controller = "GuestMenu", action = "Order" });

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=GuestMenu}/{action=Index}/{id?}");


//app.MapControllerRoute(
//    name: "login",
//    pattern: "login",
//    defaults: new { controller = "GuestMenu", action = "Login" });

//app.MapControllerRoute(
//    name: "register",
//    pattern: "register",
//    defaults: new { controller = "GuestMenu", action = "Register" });

//app.MapControllerRoute(
//    name: "cartinfo",
//    pattern: "cartinfo",
//    defaults: new { controller = "GuestMenu", action = "Cartinfo" });

//app.MapControllerRoute(
//    name: "userinfo",
//    pattern: "userinfo",
//    defaults: new { controller = "GuestMenu", action = "Userinfo" });

//app.MapControllerRoute(
//    name: "drinkinfo",
//    pattern: "drinkinfo",
//    defaults: new { controller = "GuestMenu", action = "Drinkinfo" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();