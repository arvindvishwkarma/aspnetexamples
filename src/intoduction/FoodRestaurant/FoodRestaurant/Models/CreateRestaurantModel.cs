using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FoodRestaurant.Models
{
    public class CreateOrEditRestaurantModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public List<SelectListItem> Cities { get; set; }

    }
}