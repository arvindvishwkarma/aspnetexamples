using System.ComponentModel.DataAnnotations;

namespace FoodRestaurant.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}