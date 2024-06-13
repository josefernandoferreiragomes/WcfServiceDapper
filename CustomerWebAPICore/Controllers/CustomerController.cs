using Customer.APICore;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {        
        private readonly ILogger<CustomerController> _logger;

        private readonly IConfiguration _configuration;      

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet(Name = "Customer")]
        public IEnumerable<Customer.LibraryCore.ServiceReference.Customer> Get(string? customerName)
        {
            List<Customer.LibraryCore.ServiceReference.Customer> customers = new List<Customer.LibraryCore.ServiceReference.Customer>();

            var customersResult = new Customers(_configuration).GetCustomers(
                new Customer.LibraryCore.ServiceReference.Customer()
                {
                    CustomerName = customerName
                }
            );
            if( customersResult != null && customersResult!=null)
            {
                customers = customersResult;
            }
            return customers;
        }
       
    }
}
