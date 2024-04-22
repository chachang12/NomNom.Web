using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NomNom.Web.Data;
using NomNom.Web.Models;

namespace NomNom.Web.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrderModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public GrilledCheese? GrilledCheeseObj { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    string propertyName = entry.Key;
                    ModelStateEntry propertyState = entry.Value;

                    foreach (var error in propertyState.Errors)
                    {
                        string errorMessage = error.ErrorMessage;
                        // Log or display the property name and error message
                        System.Diagnostics.Debug.WriteLine($"Property: {propertyName}, Error: {errorMessage}");
                    }
                }

                return Page();
            }

            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Create a new Order
            var order = new Order
            {
                UserId = user.Id,
                Status = "Pending",
                GrilledCheeses = new List<GrilledCheese>() // Initialize the GrilledCheeses collection
            };

            // Add the Order to the User's Orders collection
            if (user.Orders == null)
            {
                user.Orders = new List<Order>();
            }
            user.Orders.Add(order);

            // Update the User entity
            _context.Users.Update(user);

            // Save the Order to the database
            await _context.SaveChangesAsync();

            // Now that the Order has an ID, create a new GrilledCheese
            GrilledCheeseObj.OrderId = order.OrderId;

            // Add the GrilledCheese to the Order's GrilledCheeses collection
            order.GrilledCheeses.Add(GrilledCheeseObj);

            // Save the GrilledCheese to the database
            await _context.SaveChangesAsync();

            // Store the order number in TempData
            TempData["OrderNumber"] = order.OrderId;

            // Redirect to the Confirmation page
            return RedirectToPage("/Confirmation");
        }

    }
}
