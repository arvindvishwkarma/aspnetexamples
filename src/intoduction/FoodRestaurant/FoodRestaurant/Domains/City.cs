using System.ComponentModel.DataAnnotations;

namespace FoodRestaurant.Domains
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}