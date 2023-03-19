using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("BaglantiCumlesi"); // appsettings.json dosyas�ndaki Connection String c�mlesini al�yoruz
builder.Services.AddDbContext<UygulamaDbContext>(o => o.UseSqlServer(cs));

builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UygulamaDbContext>();


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

app.MapRazorPages(); // eklendi

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();

    await roleManager.CreateAsync(new IdentityRole("admin")); // burada db'ye admin rolunü asenkron olarak ekledi

    var adminUser = new Kullanici()
    {
        UserName = "kullanici@k.com",
        Email = "kullanici@k.com",
        EmailConfirmed= true,
    };

    await userManager.CreateAsync(adminUser, "Asd123.");// burada db'ye adminUser kişisini asenkron olarak ekledi

    await userManager.AddToRoleAsync(adminUser, "admin");
}



app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
