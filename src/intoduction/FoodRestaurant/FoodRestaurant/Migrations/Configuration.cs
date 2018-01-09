using FoodRestaurant.Domains;

namespace FoodRestaurant.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodRestaurant.Domains.FoodRestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FoodRestaurant.Domains.FoodRestaurantContext context)
        {
            context.Cities.AddOrUpdate(m => m.Id,
                    new City() { Id = 1, Name = "Delhi" },
                    new City() { Id = 2, Name = "Noida" },
                    new City() { Id = 3, Name = "Gurgaon" },
                    new City() { Id = 4, Name = "Greater Noida" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
