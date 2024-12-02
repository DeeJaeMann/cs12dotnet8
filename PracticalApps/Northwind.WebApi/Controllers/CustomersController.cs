using Microsoft.AspNetCore.Mvc; // For [Route], [ApiController], ControllerBase
using Northwind.EntityModels; // For Customer
using Northwind.WebApi.Repositories; // For ICustomerRepository

namespace Northwind.WebApi.Controllers
{
    // Base address: api/customers
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        // Customer injects repository registered in Program.cs
        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/customers
        // GET: api/customers/?country=[country]
        // Always returns list of customers, may be empty
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string? country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await _repo.RetrieveAllAsync();
            }
            else
            {
                return (await _repo.RetrieveAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }

        // GET: api/customers/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))] // Named route
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer? c = await _repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            return Ok(c);
        }

        // POST: api/customers
        // BODY: Customer (JSON, XML)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c == null)
            {
                return BadRequest();
            }
            Customer? addedCustomer = await _repo.CreateAsync(c);
            if (addedCustomer == null)
            {
                return BadRequest("Repository failed to create customer.");
            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = addedCustomer.CustomerId.ToLower() },
                    value: addedCustomer);
            }
        }
    }
}
