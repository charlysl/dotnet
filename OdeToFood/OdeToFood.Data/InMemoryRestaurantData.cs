﻿using System;
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

        Restaurant IRestaurantData.Add(Restaurant newRestaurant)
        {
            var id = restaurants.Max(r => r.Id) + 1;
            newRestaurant.Id = id;
            restaurants.Add(newRestaurant);
            return newRestaurant;           
        }

        int IRestaurantData.Commit()
        {
            return 0;
        }

        Restaurant IRestaurantData.Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        Restaurant IRestaurantData.GetById(int restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        int IRestaurantData.GetRestaurantCount()
        {
            return restaurants.Count();
        }

        Restaurant IRestaurantData.Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
