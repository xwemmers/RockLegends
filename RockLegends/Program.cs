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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Globale foutafhandeling met nette web pagina voor de gebruiker
    app.UseExceptionHandler("/Error");

    // En een web pagina voor specifieke HTTP Status Codes
    app.UseStatusCodePagesWithRedirects("/Error/Specific/{0}");
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


