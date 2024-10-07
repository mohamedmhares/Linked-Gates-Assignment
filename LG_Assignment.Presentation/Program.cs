using LG_Assignment.Application.Services;
using LG_Assignment.Core.Interfaces;
using LG_Assignment.Infrastructure.Data;
using LG_Assignment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
//using LG_Assignment.Application.Helper;

namespace LG_Assignment.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("No Connection String was Found");
            builder.Services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlServer(ConnectionString));
           

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Add services to the container.

            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddControllersWithViews();
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
        }
    }
}
