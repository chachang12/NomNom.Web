using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NomNom.Web.Data;
using NomNom.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomNom.Web.Pages
{
    public class ClientOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ClientOrdersModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                Orders = _context.Orders.Where(o => o.UserId == user.Id).ToList();
            }
            else
            {
                Orders = new List<Order>();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            // Update the Orders list after deletion
            var user = await _userManager.GetUserAsync(User);
            Orders = _context.Orders.Where(o => o.UserId == user.Id).ToList();

            return RedirectToPage(); // Stay on the current page
        }

    }
}
