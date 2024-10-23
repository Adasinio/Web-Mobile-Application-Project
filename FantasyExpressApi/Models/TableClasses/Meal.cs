using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("Meal")]
    public class Meal
    {
        public Meal()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        public int MealTypeId { get; set; }
        public int RestaurantId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Url { get; set; }

        [ForeignKey("MealTypeId")]
        [InverseProperty("Meals")]
        public virtual MealType? MealType { get; set; } = null!;
        [ForeignKey("RestaurantId")]
        [InverseProperty("Meals")]
        public virtual Restaurant? Restaurant { get; set; } = null!;
        [InverseProperty("Meal")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
