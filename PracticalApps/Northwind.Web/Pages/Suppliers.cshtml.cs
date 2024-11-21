using Microsoft.AspNetCore.Mvc; // For [BindProperty], IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels; // For NortwindContext

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private NorthwindContext _db;

        // For static example
        //public IEnumerable<string>? Suppliers { get; set; }
        public IEnumerable<Supplier>? Suppliers { get; set; }

        [BindProperty]
        public Supplier? Supplier { get; set; }

        public SuppliersModel(NorthwindContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";

            // For static example
            /*
            Suppliers = new[]
            {
                "Alpha Co", "Beta Limited", "Gamma Corp"
            };
            */
            Suppliers = _db.Suppliers
                .OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }

        public IActionResult OnPost()
        {
            if (Supplier is not null && ModelState.IsValid)
            {
                _db.Suppliers.Add(Supplier);
                _db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
            {
                return Page(); // Return to original page
            }
        }
    }
}
