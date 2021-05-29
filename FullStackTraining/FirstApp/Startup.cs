using FirstApp.DAO;
using FirstApp.Models;
using FirstApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(StudentsCart.GetStudentsCart);
            
            services.AddTransient<IStudent, StudentRepository>();
            services.AddTransient<IEnrollment, EnrollmentRepository>();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            
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

            app.UseSession();
            
            app.UseRouting();

            // app.UseMvcWithDefaultRoute();

            using var scope = app.ApplicationServices.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DbContentInit.Initial(context);

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Students}/{action=Resolver}");
                routes.MapRoute(name: "Cart", template: "{controller=StudentsCart}/{action}/{id?}");
            });
        }
    }
}