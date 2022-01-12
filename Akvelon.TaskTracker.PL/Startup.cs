using Akvelon.TaskTracker.BLL.Services;
using Akvelon.TaskTracker.BLL.Services.Implementations;
using Akvelon.TaskTracker.DAL.DataContext;
using Akvelon.TaskTracker.PL.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Akvelon.TaskTracker.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Akvelon.TaskTracker.PL", Version = "v1"});
            });

            services.AddDbContext<TaskTrackerDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));
            
            services.AddTransient<TaskService>();
            services.AddTransient<ProjectService>();
            services.AddTransient<SortingAndFilteringService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Akvelon.TaskTracker.PL v1");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }

            app.UseMiddleware<CustomExceptionsHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            // For use swagger theme
            app.UseStaticFiles();
        }
    }
}