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
                new Restaurant { Id = 1,  Name = "Namaste", Location = "Delhi", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 2,  Name = "Andale Guey", Location = "DF", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3,  Name = "Giorgio Trattoria", Location = "Venezia", Cuisine = CuisineType.Italian },
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        Restaurant IRestaurantData.GetById(int restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }
    }
}
