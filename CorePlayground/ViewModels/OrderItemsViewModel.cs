namespace CorePlayground.ViewModels
{
    public class OrderItemsViewModel
    {
        public int Id { get; set; }        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSize { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtDescription { get; set; }
        public string ProductArtDating { get; set; }

    }
}