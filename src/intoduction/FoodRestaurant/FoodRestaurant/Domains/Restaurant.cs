using System.ComponentModel.DataAnnotations;

namespace FoodRestaurant.Domains
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}