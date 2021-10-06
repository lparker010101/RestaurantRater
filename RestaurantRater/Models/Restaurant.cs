using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity; // Entities as models stored in the database.
using System.Linq;
using System.Web;

namespace RestaurantRater.Models // We will have models stored in different places.  Generally,
                                 // a model goes from the controller to the view and the view to
                                 // the controller.  Here we have our data level model or class.
{
    public class Restaurant // This is our entity and gets stored in our database below.  Stored in DbSet<Restaurant> Restaurants database.  
    {
        [Key]
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
    }

    public class RestaurantDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; } // A new collection of restaurant objects called Restaurants.
    }
}