using FoodBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<UserRestaurant> userList = new List<UserRestaurant>();
        public IActionResult Index()
        {
            List<string> restaurantList = new List<string>();
            foreach(Restaurant r in Restaurant.GetRestaurants())
            {
                //if there is no favorite dish return everything is tasty
                string dish = (r.FavDish == "") ? "It's all tasty" : "Signiture Dish: " + r.FavDish;
                string site = (r.Url == "") ? "Coming Soon" : r.Url;
                restaurantList.Add($"#{r.Rank}: {r.Name}, {dish},{r.Address} ,{r.Phone}, {site}   ");

            }
            return View(restaurantList);
        }
        
        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(UserRestaurant userRestaurant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                userList.Add(userRestaurant);
                List<string> userRestaurantList = new List<string>();
                foreach (UserRestaurant r in userList)
                {
                    //if there is no favorite dish return everything is tasty
                    string dish = (r.FavDish == "") ? "It's all tasty" : "Favorite Dish: " + r.FavDish;

                    userRestaurantList.Add($"{r.UserName}, {r.Name},Favorite Dish: {dish}");

                }
                return View("UserPage", userRestaurantList);
            }
        }

        public IActionResult UserPage()
        {
            List<string> userRestaurantList = new List<string>();
            foreach (UserRestaurant r in userList)
            {
                //if there is no favorite dish return everything is tasty
                string dish = (r.FavDish == "") ? "It's all tasty" : "Favorite Dish: " + r.FavDish;
                
                userRestaurantList.Add($"{r.UserName}, {r.Name},Favorite Dish: {dish}");
                
            }
            return View(userRestaurantList);
        }
            

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
