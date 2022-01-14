global using Microsoft.EntityFrameworkCore;
global using RockLegends.Models;
using Microsoft.AspNetCore.Mvc;
using RockLegends.Filters;

var builder = WebApplication.CreateBuilder(args);

// Dit Attribuut voegt automatisch ValidateAntiForgery toe aan alle HttpPost actions
builder.Services.AddControllersWithViews(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

builder.Services.AddDbContext<MusicContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MusicContext")));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


