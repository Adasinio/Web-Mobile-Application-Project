using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
            Meals = new HashSet<Meal>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
