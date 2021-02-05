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

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            CuisineItems = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public void OnPost()
        {
            // The page model is stateless, so this property
            // need to be populated for every request.
            //
            // This is not an issue for the other properties,
            // because they were already populated, as input models,
            // by the request
            CuisineItems = htmlHelper.GetEnumSelectList<CuisineType>();

            // ModelState has information about the request, for instance
            // the attempted value of a paramater that might be invalid,
            // and many; it has the information asp-for relies on
            //
            // But, most of the time, it is used whether all the parameters
            // in the request are valid.
            if (ModelState.IsValid)
            {
                restaurantData.Update(Restaurant);
                restaurantData.Commit();
            }
        }
    }
}
