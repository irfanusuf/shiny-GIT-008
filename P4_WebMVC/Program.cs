
using Microsoft.EntityFrameworkCore;
using P4_WebMVC.Data;
using P4_WebMVC.Interfaces;
using WebApI.Services;
// container
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqlDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("main")));

// add services to the container 
builder.Services.AddControllersWithViews();

   // dependency injection 
builder.Services.AddSingleton<ITokenService , TokenService>();    // dependency injection 
builder.Services.AddSingleton<IMailService , EmailService>();   

var app = builder.Build();


// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//      app.UseHsts();
// }

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
