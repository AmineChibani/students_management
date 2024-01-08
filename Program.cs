using Student_Management.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<U669885128UZsNtContext>();

//MySQL DB connecet :
string _GetconnString = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");
builder.Services.AddDbContext<U669885128UZsNtContext>(options => options.UseMySql(_GetconnString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.19-mariadb")));

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "AspApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Définit la durée de vie de la session
    options.Cookie.IsEssential = true; // Cookie essentiel pour les politiques de confidentialité
});

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
//configuration du session
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
 