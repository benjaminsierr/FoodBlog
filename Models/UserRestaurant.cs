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
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$",
            ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        public static List<UserRestaurant> userList = new List<UserRestaurant>();

        public static void addRestaurant(object obj)
        {
            userList.Add((UserRestaurant)obj);
        }
    }
}
