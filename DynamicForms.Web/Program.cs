using DynamicForms.Infrastructure.Data;
using DynamicForms.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

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
