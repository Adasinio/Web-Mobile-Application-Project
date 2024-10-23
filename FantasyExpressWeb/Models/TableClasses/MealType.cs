using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FantasyExpressApi.Models;

namespace FantasyExpressApi.Models.TableClasses
{
    [Table("MealType")]
    public class MealType
    {
        public MealType()
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

        [InverseProperty("MealType")]
        public virtual ICollection<Meal> Meals { get; set; }
    }
}