using FantasyExpressApi.Models.TableClasses;
using FantasyExpressWeb.Models.TableClasses;
using Microsoft.EntityFrameworkCore;

namespace FantasyExpressApi.Models
{
    public class FantasyExpressDbContext : DbContext
    {
        public FantasyExpressDbContext(DbContextOptions<FantasyExpressDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<MealType> MealTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; }
    }
}
