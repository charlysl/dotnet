using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1,  Name = "Namaste", Location = "Delhi", Cuisine = CuisineType.INDIAN },
                new Restaurant { Id = 2,  Name = "Andale Guey", Location = "DF", Cuisine = CuisineType.MEXICAN },
                new Restaurant { Id = 3,  Name = "Giorgio Trattoria", Location = "Venezia", Cuisine = CuisineType.ITALIAN },
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
