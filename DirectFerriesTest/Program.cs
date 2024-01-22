using DirectFerriesTest.Interfaces;
using DirectFerriesTest.Models;
using DirectFerriesTest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ConfigSettings>();
builder.Services.AddScoped<IUserProcessor, UserProcessorService>();
builder.Services.AddScoped<IValidation, ValidationService>();

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
