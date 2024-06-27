using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;

namespace Web.Views.PriceList
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreatePriceListViewModel Column { get; set; }

        
    }
}
