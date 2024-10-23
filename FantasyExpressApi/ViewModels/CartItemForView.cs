namespace FantasyExpressApi.ViewModels
{
    public class CartItemForView
    {
        public string? IdSessionOfCart { get; set; }
        public int? IdMeal { get; set; }
        public string MealData { get; set; }
        public int? IdRestaurant { get; set; }
        public string RestaurantData { get; set; }
        public decimal Quantity { get; set; }
    }
}
