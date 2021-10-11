using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // GET: Restaurant/Edit/{id}
        // Get an id from the user. 
        // Handle if the id is null
        // Find a Restaurant by that id
        // If the restaurant doesn't exist
        // Return the restaurant and the view
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // User didn't give everything needed.  
            }
            Restaurant restaurant = _db.Restaurants.Find(id); // Call the restaurant table and find restaurant by it's key.  
            if (restaurant == null)
            {
                return HttpNotFound(); // Can also code it like this... return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(restaurant);
        }

        // POST: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified; // Entry = Look through the table and see if it can find a model that matches up with one we are giving. 
                _db.SaveChanges(); // Find anything in a row that has been modified and save changes.  
                return RedirectToAction("Index");
            }
            return View(restaurant); // Returning exactly what the user gave me.
        }

        // GET: Restaurant/Details/{id}
        public ActionResult Details(int? id)
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
    }
}