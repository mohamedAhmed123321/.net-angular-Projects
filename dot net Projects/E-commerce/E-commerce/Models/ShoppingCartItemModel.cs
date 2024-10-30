namespace E_commerce.Models
{
    public class ShoppingCartItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
