using FantasyExpressApi.Models.TableClasses;

namespace FantasyExpressApi.Models
{
    public class CartData
    {
        public List<CartItem> CartItemList { get; set; }
        public decimal Total { get; set; }

        public int SelectedDelivery { get; set; }
        public int SelectedPayment { get; set; }

    }
}
