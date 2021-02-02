﻿using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{

    public class InMemoryRestaurantData : IRestaurantData
    {

        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Namaste", Location = "Delhi", Cuisine = Restaurant.CuisineType.INDIAN },
                new Restaurant { Id = 2, Name = "Andale Guey", Location = "DF", Cuisine = Restaurant.CuisineType.MEXICAN },
                new Restaurant { Id = 3, Name = "Trattoria Giorgio", Location = "Venezia", Cuisine = Restaurant.CuisineType.ITALIAN },
            };

        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
