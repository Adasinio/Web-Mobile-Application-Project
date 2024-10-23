using FantasyExpressApi.Models.TableClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FantasyExpressApi.Models.TableClasses
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public string CartSessionId { get; set; }

        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
