using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Task_Management_System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Task_Management_System.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection");

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Task_Management_System.Data.AppDbContext>(options =>
    options.UseNpgsql(@"Server=localhost;Port=5432;Database=task_management;User ID=postgres;Integrated Security=true;Pooling=true;"));

// builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<Task_Management_System.Data.AppDbContext>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

IServiceCollection context = null;

// if (Environment.OSVersion.Platform == PlatformID.Win32NT)
// {
//     context = builder.Services.AddDbContext<Task_Management_System.Data.AppDbContext>(options =>
//     options.UseSqlServer(@"Server=HOME-PC;Database=task_management;Trusted_Connection=True;"));
// }
// else
// {

//     context = builder.Services.AddDbContext<Task_Management_System.Data.AppDbContext>(options =>
// UseSqlServer(@"Server=localhost;Database=task_management;Trusted_Connection=True;")
//         options.UseNpgsql(@"Server=localhost;Port=5432;Database=task_management;User ID=postgres;Integrated Security=true;Pooling=true;"));
// }


builder.Services.Configure<AppDbContext>(a => a.Database.EnsureCreated());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
