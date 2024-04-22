using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NomNom.Web.Data;
using NomNom.Web.Models;
using System.Collections.Generic;

namespace NomNom.Web.Pages
{
    public class VendorOrdersModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public IList<Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders
                .Include(o => o.GrilledCheeses)
                .ToListAsync();
        }
    }

}
