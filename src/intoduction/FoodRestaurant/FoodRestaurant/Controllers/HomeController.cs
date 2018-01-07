using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            Restaurant restaurantToCreate = new Restaurant();
            restaurantToCreate.Name = restaurant.Name;

            FoodRestaurantContext db = new FoodRestaurantContext();
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

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            FoodRestaurantContext db = new FoodRestaurantContext();
            Restaurant restaurantToEdit = db.Restaurants.FirstOrDefault(m => m.Id == id);

            if (restaurantToEdit != null)
            {
                restaurantToEdit.Name = restaurant.Name;
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