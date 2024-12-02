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
    }
}
