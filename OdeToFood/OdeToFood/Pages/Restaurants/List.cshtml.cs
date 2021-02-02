using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message
        {
            get; set;
        }

        public IConfiguration config { get; private set; }

        private readonly IRestaurantData restaurantData;

        public IEnumerable<Restaurant> Restaurants { get; private set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;

            this.Restaurants = restaurantData.GetRestaurantsByName();
        }

        public void OnGet(string searchTerm)
        {
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);

            Message = config["Message"];
        }
    }
}
   