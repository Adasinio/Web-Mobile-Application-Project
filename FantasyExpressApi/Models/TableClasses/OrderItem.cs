using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("MealId")]
        [InverseProperty("OrderItems")]
        public virtual Meal? Meal { get; set; } = null!;
        [ForeignKey("OrderId")]
        [InverseProperty("OrderItems")]
        public virtual Order? Order { get; set; } = null!;
    }
}
