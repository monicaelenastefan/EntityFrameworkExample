using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;


namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddAutoMapper(typeof(RestaurantBranchProfile));
            services.AddScoped<IRestaurantBranchService,RestaurantBranchService>();
            services.AddScoped<IOrderTableService, OrderTableService>();
            services.AddMvc();
                
               
            ConfigureDbContext(services);
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseCors("AllowAll");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(op =>
                op.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Server")));
        }
    }
}