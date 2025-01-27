﻿using Film_lib.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class Settings
{
    public string GetTmdbApiKey()
    /*  
     *  Вместо хранения значения переменной окружения в поле класса, мы используем геттер.
     *  Это позволяет минимизировать время хранения конфиденциальных данных в памяти,
     *  что уменьшает вероятность утечки данных. 
    */
    {
        var apiKey = Environment.GetEnvironmentVariable("TMDB_API_KEY");
        if (string.IsNullOrEmpty(apiKey)) {
            throw new InvalidOperationException("TMDB_API_KEY is not set in the environment variables.");
        }
        return apiKey;
    }
}