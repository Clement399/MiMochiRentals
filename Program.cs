using Microsoft.EntityFrameworkCore;
using MiMochiRentals.Controllers;
using MiMochiRentals.DBContext;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

//StripeConfiguration.ApiKey = "sk_test_51ShRUR1SjyxQIlE1tQMeTnJlQ4TwoksiRXtxnm4E0KnsYpWgV6oh6fXobmddyEtPhj0gWHEX5GYsYuuTMaDDtYQZ00hdRhAiWj"; //test key for stripe -- new
StripeConfiguration.ApiKey = "sk_test_51ShRUD1kr1CXwBO9YUbMaTGioAW0J90Ffpv5mdDrMJbidmll3oy8G32F6xUNjlyKaGY6hsWR5zraLf1pqSO5oBGo00ZdAld90a"; //test key for stripe
//use the secret key, the publisher key is for you to publish details to stripe from your js

//stripe webhook secret
//whsec_be22bf693a9d876dbfd085985d861807f4116a2a12aa3308077ab594f7f61861

builder.Services.AddDbContext<MMContext>(options =>
{
    options.UseSqlite(connectionString);
    Console.WriteLine("DbContext registered");
});
builder.Services.AddScoped<OrderService>();
var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<MMContext>();
        Console.WriteLine($" Context resolved: {context != null}");
        Console.WriteLine($" Database path: {context.Database.GetConnectionString()}");

        context.Database.Migrate(); // Use Migrate() for migrations
        Console.WriteLine(" Migrations applied successfully");
    }
}
catch (Exception ex)
{
    Console.WriteLine($" ERROR: {ex.Message}");
    throw;
}
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
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
