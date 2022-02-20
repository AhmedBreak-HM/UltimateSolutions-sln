using Microsoft.Extensions.DependencyInjection;

namespace UltimateSolutions.WebAPI.ConfigureServices
{
    public static class AuthorizationServiceConfig
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection service)
        {
            service.AddAuthorization(
                options =>
                {
                    options.AddPolicy("RequireMemberRole", policy => policy.RequireRole("Member"));
                    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                }
            );
            return service;
        }
    }
}