using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            ////identity i?in
            //services.AddIdentity<UserPerson, UserRole>().AddEntityFrameworkStores<Context>();

            //services.AddDbContext<Context>(x =>
            //    x.UseSqlServer("server=LAPTOP-BR4E36S8;database=NewsDB;user=sa;password=berkay345..;integrated security=true;")
            //);
            services.AddDefaultIdentity<UserPerson>()
                .AddRoles<UserRole>()
                .AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddMvc().AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<UserValidator>();
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = "/Error/Index";
            }

            );

            //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<Context>();


            //services.AddRazorPages();
            services.AddTransient<IValidator<UserPerson>, UserValidator>();

            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<INewService, NewManager>();
            //services.AddScoped<ICommentService, CommentManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //      name: "areas",
            //      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //});
        }
    }
}
