using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddSwaggerGen();
            services.AddControllers();

            services.AddMvc();
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
    }
}