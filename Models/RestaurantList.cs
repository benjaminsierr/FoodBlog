using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBlog.Models
{
    public class RestaurantList
    {
        private static List<UserRestaurant> userRestaurants = new List<UserRestaurant>();

        public static IEnumerable<UserRestaurant> UserRestaurants => userRestaurants;

        public static void AddRestaurant(UserRestaurant userRestaurant)
        {
            userRestaurants.Add(userRestaurant);
        }
    }
}
