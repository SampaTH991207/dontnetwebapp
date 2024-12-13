using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;  // Add this namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Check for Development environment
if (app.Environment.IsDevelopment())  // Use `app.Environment` instead of `IWebHostEnvironment`
{
    app.UseDeveloperExceptionPage();
}

// Serve static files
app.UseStaticFiles();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
