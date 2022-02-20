using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltimateSolutions.Application.Contracts;
using UltimateSolutions.Infrastructure.Data;
using UltimateSolutions.Infrastructure.Repositories;

namespace UltimateSolutions.Infrastructure
{
    public static class PersistenceLayerContainer
    {
        public static IServiceCollection AddPersistenceLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IPorductRepository, PorductRepository>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            return services;
        }
    }
}