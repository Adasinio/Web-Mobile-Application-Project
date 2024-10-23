using FantasyExpressApi.Helpers;
using FantasyExpressApi.Models.TableClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class MealForView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int MealTypeId { get; set; }
        public int RestaurantId { get; set; }
        public virtual string MealTypeData { get; set; }
        public string? Url { get; set; }
        public MealForView()
        {
            
        }

        public static implicit operator MealForView(Meal source)
        {
            var result = new MealForView().CopyProperties(source);
            result.MealTypeData = source?.MealType?.Name == null ? String.Empty : source.MealType.Name;
            return result;
        }

        public static implicit operator Meal(MealForView source)
        {
            var result = new Meal().CopyProperties(source);
            result.IsActive = true;
            result.CreatedDate = DateTime.Now;
            return result;
        }
    }
   
}

