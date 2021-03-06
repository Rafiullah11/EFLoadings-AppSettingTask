using EFLoadings_AppSettingTask.CustomSetting;
using EFLoadings_AppSettingTask.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option => 
                option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.Configure<CustomAppSetting>(builder
                .Configuration.GetSection(CustomAppSetting.SectionName));
builder.Services.AddControllersWithViews();

builder.Services.AddOptions();

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
