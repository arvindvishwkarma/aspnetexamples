using System.Data.Entity;

namespace FoodRestaurant.Domains
{
    public class FoodRestaurantContext : DbContext
    {
        public FoodRestaurantContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants");
            modelBuilder.Entity<City>().ToTable("City");

            base.OnModelCreating(modelBuilder);
        }
    }
}