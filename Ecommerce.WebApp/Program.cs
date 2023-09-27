using Ecommerce.Application.Configuraitons;
using Ecommerce.Database;
using Ecommerce.Models.IdentityModels;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Services.Abstractions.Base;
using Ecommerce.WebApp.Middlewares;
using Ecommerce.WebApp.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//--> Service Resolve/Dependency Resolve


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IDbContextSwitchService, DbContextSwitchService>();

builder.Services.AddScoped<RandomClass>();
//Transient, Scoped, Singleton 
DependencyConfigurations.Configure(builder.Services);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.Cookie.Name = ".EcommerceApp.Session";
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication("Cookies") // Sets the default scheme to cookies
            .AddCookie("Cookies", options =>
            {
                options.AccessDeniedPath = "/account/denied";
                options.LoginPath = "/account/login";
            });

var app = builder.Build();

//Middleware 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseDbContextSwitcher();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


