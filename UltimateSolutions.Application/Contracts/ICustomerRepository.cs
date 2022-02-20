using UltimateSolutions.Domain.Models;
using UltimateSolutions.Domain.SeedWork;

namespace UltimateSolutions.Application.Contracts
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}