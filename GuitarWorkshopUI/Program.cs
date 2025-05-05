using GuitarWorkshopUI.Interfaces;
using GuitarWorkshopUI.Services;
using GutarWorkshopDB.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "MyCookieAuth";
    options.DefaultChallengeScheme = "MyCookieAuth";
    options.DefaultAuthenticateScheme = "MyCookieAuth";
})
.AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyAuthCookie";
    options.LoginPath = "/User/Login"; // путь к странице входа
    options.AccessDeniedPath = "/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});
builder.Services.AddAuthorization(); 

builder.Services.AddPooledDbContextFactory<GuitarWorkshopContext>(options =>
{
    options.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=GuitarWorkshop;");
});

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
