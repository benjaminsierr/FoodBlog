using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FoodBlog.Models
{
    public class UserRestaurant
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        public string FavDish { get; set; }
        
        public static UserRestaurant[] GetUserRestaurants()
        {

            return new UserRestaurant[] { null };
        }
    }
}
