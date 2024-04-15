using Microsoft.EntityFrameworkCore;
using MVCFRIB.Data;

namespace MVCFRIB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MessageContext>(options =>
                options.UseSqlite($"Data Source=./Messages.db"));

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
            app.MapControllerRoute(
                name: "DisplayMessage",
                pattern: "{controller=Messages}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "ListMessage",
                pattern: "{controller=Message}/{action=ListMessage}/{id?}");
            app.MapControllerRoute(
                name: "SendMessage",
                pattern: "{controller=SendMessage}/{action=SendMessage}/{id?}");

            app.Run();
        }
    }
}
