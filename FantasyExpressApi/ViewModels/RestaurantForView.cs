using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class RestaurantForView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<MealForView> Meals { get; set; }

        public RestaurantForView()
        {
            Meals = new HashSet<MealForView>();
        }
    }
}
