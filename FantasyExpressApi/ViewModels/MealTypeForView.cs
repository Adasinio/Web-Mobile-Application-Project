using FantasyExpressApi.Helpers;
using FantasyExpressApi.Models.TableClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class MealTypeForView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<MealForView> Meals { get; set; }

        public MealTypeForView()
        {
            Meals = new List<MealForView>(); 
        }

        public static implicit operator MealTypeForView(MealType source)
        {
            var result = new MealTypeForView().CopyProperties(source);
            //result.Meals = source?.Meals?.Any() == true ? source.Meals.Select(meal => (MealForView)meal).ToList() : new List<MealForView>();
            return result;
        }

        public static implicit operator MealType(MealTypeForView source)
        {
            var result = new MealType().CopyProperties(source);
            result.CreatedDate = DateTime.Now;
            result.IsActive = true;
            return result;
        }
    }
}
