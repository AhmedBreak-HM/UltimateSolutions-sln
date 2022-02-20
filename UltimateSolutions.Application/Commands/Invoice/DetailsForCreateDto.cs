namespace UltimateSolutions.Application.Commands.Invoice
{
    public class DetailsForCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}