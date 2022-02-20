using UltimateSolutions.Application.Contracts;
using UltimateSolutions.Domain.Models;
using UltimateSolutions.Infrastructure.Data;

namespace UltimateSolutions.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}