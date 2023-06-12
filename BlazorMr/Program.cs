using BlazorMr.Database;
using BlazorMr.Preview;
using BlazorMr.Repositories;
using BlazorMr.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorMr;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddDbContextFactory<MediaContext>(
            options => options.UseSqlServer(
                builder.Configuration.GetConnectionString(MediaContext.ConnectionStringName)));

        builder.Services.AddScoped<IPreviewManager, PreviewManager>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        var app = builder.Build();

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
    }
}