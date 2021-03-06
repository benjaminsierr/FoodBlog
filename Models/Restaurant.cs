﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBlog.Models
{
    public class Restaurant
    {
        public Restaurant(int rank)
        {
            Rank = rank;
        }
        [Required]
        public int Rank { get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? FavDish { get; set; }
        public string Address { get; set; }
        [Phone]
        public long? Phone { get; set; }
        public string? Url { get; set; } = "Coming Soon";

        public static Restaurant[] GetRestaurants()
        {

            Restaurant r1 = new Restaurant(1)
            {
                Name = "K's Kitchen",
                FavDish = "Katsu Curry",
                Address = "322 W Center St",
                Phone = 3852017523,
                Url = "http://ksjapanesekitchen.com/menu/"
            };

            Restaurant r2 = new Restaurant(2)
            {
                Name = "Station 22",
                FavDish = "Chicken & Waffles",
                Address = "204 Center St",
                Phone = 8012222222,
                Url = "https://station22cafe.getbento.com/menus/"
            };

            Restaurant r3 = new Restaurant(3)
            {
                Name = "Communal",
                FavDish = "Fillet Mignon",
                Address = "1234 University Ave",
                Phone = 801333333,
                Url = "https://communalrestaurant.getbento.com/"
            };

            Restaurant r4 = new Restaurant(4)
            {
                Name = "Brick Oven Pizza",
                FavDish = null,
                Address = "85 W 800 N",
                Phone = 8014444444,
                Url = "https://communalrestaurant.getbento.com/"
            };

            Restaurant r5 = new Restaurant(5)
            {
                Name = "J Dawgs",
                FavDish = null,
                Address = "A Truck Stand",
                Phone = 8015555555,
                Url = "https://communalrestaurant.getbento.com/"
            };


            return new Restaurant[] { r1,r2,r3,r4,r5 };
        }

    }
}
