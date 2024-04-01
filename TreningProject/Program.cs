using Microsoft.EntityFrameworkCore;
using TreningProject.Abstractions;
using TreningProject.Abstractions.Services;
using TreningProject.Infrastructure;
using TreningProject.Logic.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WeatherDbConnection"))
);

builder.Services.AddScoped<IRepository<WeatherCondition>, Repository<ApplicationDbContext, WeatherCondition>>();
builder.Services.AddScoped<IWeatherConditionService, WeatherConditionService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
