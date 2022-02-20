using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UltimateSolutions.WebAPI.ConfigureServices
{
    public static class SwaggerGenServiceConfig
    {
        public static IServiceCollection AddSwaggerGenService(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please Bearer and then token in the field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
            });
            return service;
        }
    }
}