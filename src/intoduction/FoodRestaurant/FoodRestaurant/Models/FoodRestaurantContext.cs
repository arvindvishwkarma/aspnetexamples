using System.Data.Entity;

namespace FoodRestaurant.Models
{
    public class FoodRestaurantContext : DbContext
    {
        public FoodRestaurantContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants");

            base.OnModelCreating(modelBuilder);
        }
    }
}