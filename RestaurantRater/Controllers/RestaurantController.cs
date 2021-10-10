using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant / Index
        public ActionResult Index() // To display all restaurants that exist in a table format.
        {
            return View(_db.Restaurants.ToList());
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant); //_db is not the actual database.  It is a snapshot, so we need to take the changes made and save them.
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // User didn't give everything needed.  
            }
            Restaurant restaurant = _db.Restaurants.Find(id); // Calling the database table Restaurants and trying to find the restaurant by it's key.
            if (restaurant == null)
            {
                return HttpNotFound(); // Couldn't find what user is looking for.
            }
            return View(restaurant);
        }

        // POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}