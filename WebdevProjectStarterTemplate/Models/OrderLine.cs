namespace WebdevProjectStarterTemplate.Models
{
    public class OrderLine
    {

        public int  ProductId { get; set; }
        public int  RTableId { get; set; }
        public int  Amount { get; set; }
        public int AmountPaid { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Name { get; set; }
    }
}
