using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("Delivery")]
    public class Delivery
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Delivery")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
