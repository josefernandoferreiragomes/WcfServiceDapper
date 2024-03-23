using CustomerAPICore;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace CustomerWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {              

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Customer")]
        public IEnumerable<Customer> Get(string? customerName)
        {
            List<Customer> customers    = new List<Customer>();

            customers = new Customers().GetCustomers(customerName);  
            return customers;
        }
    }
}
