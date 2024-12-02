using System.Diagnostics; // For Activity
using Microsoft.AspNetCore.Mvc; // For Controller, IActionResult
using Northwind.Mvc.Models; // For ErrorViewModel
using Northwind.EntityModels; // For NorthwindContext
using Microsoft.EntityFrameworkCore; // For Include, ToListAsync

namespace Northwind.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _db;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, NorthwindContext db, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _db = db;
            _clientFactory = httpClientFactory;
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        // Non-Async method
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            // Logging demo
            /*
            _logger.LogError("This is a serious error (not really!)");
            _logger.LogWarning("This is your first warning!");
            _logger.LogWarning("Second warning!");
            _logger.LogInformation("I am in the Index method of the HomeController.");
            */
            // Non Async
            /*
            HomeIndexViewModel model = new
                (
                VisitorCount: Random.Shared.Next(1, 1001),
                Categories: _db.Categories.ToList(),
                Products: _db.Products.ToList()
            );
            */
            HomeIndexViewModel model = new
            (
                VisitorCount: Random.Shared.Next(1, 1001),
                Categories: await _db.Categories.ToListAsync(),
                Products: await _db.Products.ToListAsync()
            );
            return View(model); // Pass the model to the view
        }

        [Route("private")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // non-Async
        //public IActionResult ProductDetail(int? id, string alertstyle = "success")
        public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
        {
            ViewData["alertstyle"] = alertstyle;
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }

            // non-Async
            /*
            Product? model = _db.Products.Include(p => p.Category)
                .SingleOrDefault(p => p.ProductId == id);
            */
            Product? model = await _db.Products.Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.ProductId == id);

            if (model is null)
            {
                return NotFound($"ProductId {id} not found.");
            }

            return View(model); // Pass model to view then return result
        }

        // This action method will handle GET and other requests except POST
        public IActionResult ModelBinding()
        {
            return View(); // The page with a form to submit
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new(
                Thing: thing, HasErrors: !ModelState.IsValid, ValidationErrors: ModelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage)
                );

            return View(model); // Show the model bound thing
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return BadRequest("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
            }

            IEnumerable<Product> model = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No products cost more than {price:C}.");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");

            return View(model);
        }

        // Action for calling Northwind Web API service
        public async Task<IActionResult> Customers(string country)
        {
            string uri;

            if (string.IsNullOrEmpty(country))
            {
                ViewData["Title"] = "All Customers Worldwide";
                uri = "api/customers";
            }
            else
            {
                ViewData["Title"] = $"Customers in {country}";
                uri = $"api/customers/?country={country}";
            }

            HttpClient client = _clientFactory.CreateClient(name: "Northwind.WebApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<Customer>? model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

            return View(model);
        }
    }
}
