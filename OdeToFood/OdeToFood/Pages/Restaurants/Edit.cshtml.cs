using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> CuisineItems { get; private set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        // The restaurantId parameter is optional.
        //
        // This means it now has the HasValue and Value properties,
        // and this is because it implicitly implements the Nullable interface
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
                if (Restaurant == null)
                {
                    return RedirectToPage("/NotFound");
                }
            }
            else
            {
                Restaurant = new Restaurant();
            }

            CuisineItems = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        // If you ommit the "public" modifier, there is no warning,
        // the page will still do something, but won't execute the
        // method; this can be very frustrating until you realize
        // what is going on.
        public IActionResult OnPost()
        {
            // ModelState has information about the request, for instance
            // the attempted value of a paramater that might be invalid,
            // and many; it has the information asp-for relies on
            //
            // But, most of the time, it is used whether all the parameters
            // in the request are valid.
            if (!ModelState.IsValid)
            {
                // The page model is stateless, so this property
                // need to be populated for every request.
                //
                // This is not an issue for the other properties,
                // because they were already populated, as input models,
                // by the request
                CuisineItems = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }

            // We assume that the database will never generate ids
            // that are 0, which is that of a new restaurant.
            if (Restaurant.Id == 0)
            {
                restaurantData.Add(Restaurant);
            }
            else
            {
                restaurantData.Update(Restaurant);
            }

            restaurantData.Commit();

            // It is bad practice after making a POST request to
            // stay the same URL. The reason is that a POST request
            // typically creates new resources, which is not what you
            // may want to happen if you refresh the page. This is the
            // reason browser warn you before resubmitting such a page.
            //
            // The POST-GET-REDIRECT pattern:
            //
            // The conventional way around this is to redirect to a
            // "safe" page, one that would perform a GET request if
            // refreshed.
            //
            // C# allows you to create typeless objects, which is convenient
            // in this case to pass the route for the redirect.
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
        }
    }
}
