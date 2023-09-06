

using B.Tech.Models;
using B.Tech.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace B.Tech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
            //builder.Services.AddSession(options =>
            // {
            //     options.IdleTimeout = TimeSpan.FromMinutes(30); 
            //     options.Cookie.HttpOnly = true;
            //     options.Cookie.IsEssential = true;
            // });

            //builder.Services.AddSingleton(x =>
            //      new PaypalClient(
            //                builder.Configuration["PayPalOptions:ClientId"],
            //                builder.Configuration["PayPalOptions:ClientSecret"],
            //                builder.Configuration["PayPalOptions:Mode"]
            //            )
            //        );
            //builder.Services.Configure<PayPalSettings>(builder.Configuration.GetSection("PayPalSettings"));
            //builder.Services.AddControllersWithViews();


            builder.Services.AddSession();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddScoped<IProduct, ProductRepository>();
            builder.Services.AddScoped<ICategory, CategoryRepository>();
            builder.Services.AddScoped<IOrder, OrderRepository>();
         
            builder.Services.AddScoped<ILogin, CostomerRepository>();
            //builder.Services.AddScoped<ILogin, CostomerRepository>();
            builder.Services.AddScoped<IProduct_Order, Product_OrderRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}