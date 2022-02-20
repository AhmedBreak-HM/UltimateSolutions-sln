using System.Collections.Generic;

namespace UltimateSolutions.Domain.Models
{
    public class InvoiceMaster
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Gtotal { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}