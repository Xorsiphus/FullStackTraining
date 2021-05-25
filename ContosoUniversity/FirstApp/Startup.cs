using System;
using FirstApp.Controllers;
using FirstApp.DAO;
using FirstApp.Mocks;
using FirstApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IItems, MockItems>();
            services.AddTransient<IItemsCategory, MockCategory>();
            services.AddTransient<IStudent, StudentRepository>();
            services.AddTransient<IEnrollment, EnrollmentRepository>();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            
            services.AddControllersWithViews(mvcOtions=>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseMvcWithDefaultRoute();

            using var scope = app.ApplicationServices.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DBContentInit.Initial(context);

            // app.UseEndpoints(endpoints =>
            //            {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            //     
            // });
        }
    }
}