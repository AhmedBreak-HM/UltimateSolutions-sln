using UltimateSolutions.Application.Contracts;
using UltimateSolutions.Domain.Models;
using UltimateSolutions.Infrastructure.Data;

namespace UltimateSolutions.Infrastructure.Repositories
{
    public class PorductRepository : BaseRepository<Product>, IPorductRepository
    {
        private readonly ApplicationDbContext _context;

        public PorductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}