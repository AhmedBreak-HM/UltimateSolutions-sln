namespace UltimateSolutions.Domain.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public int InvoiceMasterId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public InvoiceMaster InvoiceMaster { get; set; }
    }
}