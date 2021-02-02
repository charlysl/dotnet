using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        public string Message
        {
            get; set;
        }
        public IConfiguration config { get; private set; }

        public ListModel(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            this.config = config;
        }

        public void OnGet()
        {
            Message = config["Message"];
        }
    }
}
   