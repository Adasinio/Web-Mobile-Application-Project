using FantasyExpressWeb.Models.TableClasses;

namespace FantasyExpressWeb.Models
{
    public class CartData
    {
        public List<CartItem> CartItemList { get; set; }
        public decimal Total { get; set; }
    }
}
