using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class OrderItemForView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual MealForView Meal { get; set; } = null!;
        public virtual OrderForView Order { get; set; } = null!;
    }
}
