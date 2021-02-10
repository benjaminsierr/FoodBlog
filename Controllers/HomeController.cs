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

        
        public IActionResult Index()
        {
            List<string> restaurantList = new List<string>();
            foreach(Restaurant r in Restaurant.GetRestaurants())
            {
                //if there is no favorite dish return everything is tasty
                string? dish = r.FavDish ?? "It's all tasty!";
                //if there is no url pass in "Coming Soon"
                restaurantList.Add($"#{r.Rank}: {r.Name}, {dish}, {r.Address} ,{r.Phone}, {r.Url}   ");

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
                //UserRestaurant.addRestaurant(userRestaurant);
                //List<string> userRestaurantList = new List<string>();
                //foreach (UserRestaurant r in UserRestaurant.userList)
                //{
                    //if there is no favorite dish return everything is tasty
                  //  string dish = (r.FavDish == "" ^ r.FavDish is null) ? "It's all tasty" : r.FavDish;

 //                   userRestaurantList.Add($"{r.UserName}, {r.Name}, Favorite Dish: {dish}, {r.Phone}");
 
 //               }

                RestaurantList.AddRestaurant(userRestaurant);

                return View("UserPage", RestaurantList.UserRestaurants);
            }
        }

        public IActionResult UserPage()
        {
            List<string> userRestaurantList = new List<string>();
            foreach (UserRestaurant r in UserRestaurant.userList)
            {
                //if there is no favorite dish return everything is tasty
                string dish = (r.FavDish == "") ? "It's all tasty" : r.FavDish;
                userRestaurantList.Add($"{r.UserName}, {r.Name}, Favorite Dish: {dish}, {r.Phone}");
                
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
