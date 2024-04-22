using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NomNom.Web.Pages
{
    public class ConfirmationModel : PageModel
    {
        public int OrderNumber { get; set; }

        public void OnGet()
        {
            if (TempData["OrderNumber"] is int orderNumber)
            {
                OrderNumber = orderNumber;
            }
        }
    }

}
