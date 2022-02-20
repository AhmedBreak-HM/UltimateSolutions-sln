using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UltimateSolutions.Domain.Models;
using UltimateSolutions.Infrastructure.Data;

namespace UltimateSolutions.WebAPI.ConfigureServices
{
    public static class IdentityServiceConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service)
        {
            service.AddIdentity<UserApplication, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            return service;
        }
    }
}