namespace E_commerce.Models
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel()
        {
            lstItems=new List<ShoppingCartItemModel>();
        }

        public List<ShoppingCartItemModel> lstItems { get; set; }
        public decimal Total { get; set; }
        public string PromoCode { get; set; }
    }
}
