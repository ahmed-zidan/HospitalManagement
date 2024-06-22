using Hospital.Core.Identity;
using Hospital.Infrastructure.Data;
using Hospital.Infrastructure.Services;
using Hospital.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailSender, EmailSender>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDb")));
builder.Services.AddApplicationServices();


builder.Services.AddRazorPages();
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

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeMain}/{action=Index}/{id?}");*/

app.MapControllerRoute(
    name: "area",
    pattern: "{Area=Admin}/{controller=Hospital}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
