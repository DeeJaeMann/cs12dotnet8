using Microsoft.AspNetCore.Mvc;
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
    }
}
