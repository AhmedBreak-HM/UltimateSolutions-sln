using System.Collections.Generic;
using UltimateSolutions.Domain.SeedWork;

namespace UltimateSolutions.Domain.Models
{
    public class Customer : BaseEntity<int>
    {
        public ICollection<InvoiceMaster> InvoiceMaster { get; set; }
    }
}