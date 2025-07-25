using BLL.IServices;
using BLL.Services;
using DAL.DBContexts;
using DAL.IRepositories;
using DAL.Repositories;
using eStoreG6.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace eStoreG6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<eStoreDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            // Add services to the container.
            builder.Services.AddScoped<ICateRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = new PathString("/Account/Logout");
                    options.Cookie.Name = "eStoreG6AuthCookie";
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                });
            builder.Services.AddAuthorization();
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
