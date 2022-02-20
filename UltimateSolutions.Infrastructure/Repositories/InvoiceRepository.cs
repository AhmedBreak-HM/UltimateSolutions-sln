using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.Invoice;
using UltimateSolutions.Application.Contracts;
using UltimateSolutions.Application.Queries.InvoiceMaster.GetMasterWithCustomerById;
using UltimateSolutions.Domain.Models;
using UltimateSolutions.Infrastructure.Data;

namespace UltimateSolutions.Infrastructure.Repositories
{
    public class InvoiceRepository : BaseRepository<InvoiceMaster>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateInvoice(CreateInvoiceCommand createInvoiceCommand)
        {
            var masterDetilas = new InvoiceMaster();
            masterDetilas.CustomerId = createInvoiceCommand.CustomerId;
            masterDetilas.Gtotal = createInvoiceCommand.Gtotal;
            masterDetilas.InvoiceDetails = new List<InvoiceDetails>();
            foreach (var itemDetials in createInvoiceCommand.InvoiceDetails)
            {
                var detials = new InvoiceDetails()
                {
                    ProductId = itemDetials.ProductId,
                    Quantity = itemDetials.Quantity,
                    Price = itemDetials.Price
                };
                masterDetilas.InvoiceDetails.Add(detials);
            }
            var masterDetialsForReturn = await AddAsync(masterDetilas);
            return masterDetialsForReturn.Id;
        }

        public async Task<InvoiceMasterForReturnDto> GetMasterWithCustomerById(int id)
        {
            var masterCustomer = await (from m in _context.InvoicesMaster
                                        join c in _context.Customers
                                        on m.CustomerId equals c.Id
                                        select new InvoiceMasterForReturnDto
                                        {
                                            Id = m.Id,
                                            CustomerName = c.Name,
                                            Gtotal = m.Gtotal
                                        }).Where(m => m.Id == id).ToListAsync();
            return masterCustomer.FirstOrDefault();
        }
    }
}