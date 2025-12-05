using Microsoft.EntityFrameworkCore;
using MiMochiRentals.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<MMContext>(options =>
{
    options.UseSqlite(connectionString);
    Console.WriteLine("DbContext registered");
});
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
