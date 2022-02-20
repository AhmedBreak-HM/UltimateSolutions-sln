using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimateSolutions.Application;
using UltimateSolutions.Infrastructure;
using UltimateSolutions.WebAPI.ConfigureServices;
using UltimateSolutions.WebAPI.Middlewares;

namespace UltimateSolutions.WebAPI
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
            // add Core Application Layer Container
            services.AddApplicationLayerServices();
            // add Core Persistence Layer Container
            services.AddPersistenceLayerServices(Configuration);

            // Add Identity ConfigureServices
            services.AddIdentityService();

            // Add Authentication
            services.AddAuthenticationService(Configuration);

            // Add Authorization
            services.AddAuthorizationService();

            // Add Swagger

            services.AddSwaggerGenService();

            services.AddControllers();

            // Add Cors-Origin
            var policy = Configuration.GetSection("Cors-Origin:Policy").Value;
            var origin = Configuration.GetSection("Cors-Origin:SPA-App").Value;
            services.AddCors(o => o.AddPolicy(policy, builder =>
            {
                builder.WithOrigins(origin).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var policy = Configuration.GetSection("Cors-Origin:Policy").Value;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UltimateSolutions.WebAPI v1"));
            }

            // Add Golable ExceptionHandler in Prodaction mode
            app.UseGolableExceptionMiddleware();

            // add Cors
            app.UseCors(policy);

            app.UseHttpsRedirection();

            app.UseRouting();

            // add authentication Midllware
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}