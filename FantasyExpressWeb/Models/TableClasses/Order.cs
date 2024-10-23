using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("DeliveryId")]
        [InverseProperty("Orders")]
        public virtual Delivery? Delivery { get; set; } = null!;
        [ForeignKey("PaymentId")]
        [InverseProperty("Orders")]
        public virtual Payment? Payment { get; set; } = null!;
        [InverseProperty("Order")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
