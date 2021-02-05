using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantsData;

        public DetailsModel(IRestaurantData restaurantsData)
        {
            this.restaurantsData = restaurantsData;
        }

        public Restaurant Restaurant { get; set; }

        // This is the best way of modeling a temporary message,
        // a page model property
        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantsData.GetById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
