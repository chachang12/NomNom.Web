using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NomNom.Web.Data;
using NomNom.Web.Models;

namespace NomNom.Web.Pages
{
    public class FulfillOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FulfillOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await _context.Orders
                .Include(o => o.GrilledCheeses)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Status = "Complete";
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToPage("/VendorOrders");
        }
    }
}
