using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodRestaurant.Domains;
using FoodRestaurant.Models;

namespace FoodRestaurant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            FoodRestaurantContext db = new FoodRestaurantContext();
            List<Restaurant> restaurantsList = db.Restaurants.ToList();
            return View(restaurantsList);
        }

        public ActionResult Create()
        {
            CreateOrEditRestaurantModel model = new CreateOrEditRestaurantModel();

            FoodRestaurantContext db = new FoodRestaurantContext();
            model.Cities = db.Cities.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateOrEditRestaurantModel restaurant)
        {
            FoodRestaurantContext db = new FoodRestaurantContext();

            if (!ModelState.IsValid)
            {
                restaurant.Cities = db.Cities.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();
                return View(restaurant);
            }

            Restaurant restaurantToCreate = new Restaurant();
            restaurantToCreate.Name = restaurant.Name;
            restaurantToCreate.CityId = restaurant.CityId;

            db.Restaurants.Add(restaurantToCreate);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            FoodRestaurantContext db = new FoodRestaurantContext();
            Restaurant restaurant = db.Restaurants.FirstOrDefault(m => m.Id == id);
            if (restaurant == null)
            {
                return RedirectToAction("List");
            }

            CreateOrEditRestaurantModel model = new CreateOrEditRestaurantModel();
            model.Id = restaurant.Id;
            model.Name = restaurant.Name;
            model.CityId = restaurant.CityId;

            model.Cities = db.Cities.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateOrEditRestaurantModel restaurant)
        {
            FoodRestaurantContext db = new FoodRestaurantContext();

            if (!ModelState.IsValid)
            {
                restaurant.Cities = db.Cities.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();
                return View(restaurant);
            }

            
            Restaurant restaurantToEdit = db.Restaurants.FirstOrDefault(m => m.Id == id);

            if (restaurantToEdit != null)
            {
                restaurantToEdit.Name = restaurant.Name;
                restaurantToEdit.CityId = restaurant.CityId;
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            FoodRestaurantContext db = new FoodRestaurantContext();
            Restaurant restaurant = db.Restaurants.FirstOrDefault(m => m.Id == id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}