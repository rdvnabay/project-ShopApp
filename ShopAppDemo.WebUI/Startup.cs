using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.BusinessLayer.Concrete;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore;
using ShopAppDemo.WebUI.EmailServices;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Middlewares;

namespace ShopAppDemo.WebUI
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICardService, CardManager>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<IProductDal, EFCoreProductDal>();
            services.AddScoped<ICategoryDal, EFCoreCategoryDal>();
            services.AddScoped<ICardDal, EFCoreCardDal>();
            services.AddScoped<IOrderDal,EFCoreOrderDal>();
         
  
            services.AddDbContext<ShopAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ShopAppDemo.WebUI")));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ShopAppDemo.WebUI")));


            services.AddTransient<IEmailSender, EmailSender>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                //options.User.AllowedUserNameCharacters"";
                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login/";
                options.LogoutPath = "/account/logout/";
                options.AccessDeniedPath = "/account/accessdenied/";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite=SameSiteMode.Strict
                    
                };
            });
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseStaticFiles();
            app.CustomStaticFiles();
          
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
  name: "account",
  pattern: "account/{action}",
 defaults: new { controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
    name: "productsByCategory",
    pattern: "products/{category?}",
   defaults: new { controller = "Product", action = "Index" });

                //Admin Category
                endpoints.MapControllerRoute(
                   name: "adminCategory",
                   pattern: "admin/categories",
                  defaults: new { controller = "Category", action = "List" }
                  );

                endpoints.MapControllerRoute(
                 name: "adminCategory",
                 pattern: "admin/category/add",
                defaults: new { controller = "Category", action = "Add" }
                );

                endpoints.MapControllerRoute(
                  name: "adminCategory",
                  pattern: "admin/category/edit/{id?}",
                 defaults: new { controller = "Category", action = "Edit" }
                 );

                //Admin Product

                endpoints.MapControllerRoute(
                   name: "adminProduct",
                   pattern: "admin/products",
                  defaults: new { controller = "Product", action = "List" }
                  );

                endpoints.MapControllerRoute(
          name: "adminProduct",
          pattern: "admin/product/add",
         defaults: new { controller = "Product", action = "Add" }
         );

                endpoints.MapControllerRoute(
               name: "adminProduct",
               pattern: "admin/products/edit/{id?}",
              defaults: new { controller = "Product", action = "Edit" }
              );




                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
            SeedData.EnsurePopulated(app);
            AppUserRole.DefaultUserRole(userManager, roleManager, Configuration).Wait();
        }
    }
}
