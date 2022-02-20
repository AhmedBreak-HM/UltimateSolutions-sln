namespace UltimateSolutions.Application.Queries.InvoiceDetails.GetAllDetails
{
    public class InvoiceDetailsForReturnDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}