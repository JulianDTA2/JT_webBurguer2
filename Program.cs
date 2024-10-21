using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JT_webBurguer2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JT_webBurguer2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JT_webBurguer2Context") ?? throw new InvalidOperationException("Connection string 'JT_webBurguer2Context' not found.")));

// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
