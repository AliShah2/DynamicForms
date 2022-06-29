using AutoMapper;
using DynamicForms.Core.Dtos.MappingProfiles;
using DynamicForms.Infrastructure.Data;
using DynamicForms.Services;
using DynamicForms.Services.Interfaces;
using DynamicForms.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<ApplicationDbContext>(
        options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
                    .MigrationsAssembly("DynamicForms.Infrastructure"));
        }
);

builder.Services.AddMudServices();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(SupportCaseTypeProfile)));

builder.Services.AddScoped<ISupportTypeService, SupportTypeService>();
builder.Services.AddScoped<ISupportRequestService, SupportRequestService>();

var app = builder.Build();

//Create db, execute migrations, seed data
using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    dbContext.Seed();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
