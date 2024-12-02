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
        public async Task<IEnumerable<Customer>> GetCustomer(string? country)
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
    }
}
