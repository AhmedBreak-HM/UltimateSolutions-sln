using System.Collections.Generic;
using UltimateSolutions.Domain.SeedWork;

namespace UltimateSolutions.Domain.Models
{
    public class Product : BaseEntity<int>
    {
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}