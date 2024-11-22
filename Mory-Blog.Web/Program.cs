using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mory_Blog.Datalayer;
using Mory_Blog.CoreLayeer.Sevices;
using Mory_Blog.Datalayer.Context;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserServices , Userservice>();
builder.Services.AddDbContext<BlogContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Defualt"));
});
builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(option =>
    {
        option.LoginPath = "/Auth/Login";
        option.LogoutPath = "/Auth/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(30);
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();