using Microsoft.EntityFrameworkCore;
using StudentPortal_API_V2;
using StudentPortal_Web.Services;
using StudentPortal_Web.Services.IService;
using StudentsPortal_Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingsConfig));

builder.Services.AddHttpClient<IStudentService,StudentService>();
builder.Services.AddScoped<IStudentService,StudentService>();

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
    pattern: "{controller=StudentPortal}/{action=Index}/{id?}");

app.Run();
