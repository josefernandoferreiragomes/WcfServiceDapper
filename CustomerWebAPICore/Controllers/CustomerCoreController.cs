using Customer.APICore;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerCoreController : ControllerBase
    {        
        private readonly ILogger<CustomerController> _logger;

        private readonly IConfiguration _configuration;      

        public CustomerCoreController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }       

        [HttpGet(Name = "CustomerCore")]
        public IEnumerable<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> Get(string? customerName)
        {
            List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> customers = new List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>();

            var customersResult = new CustomersCore(_configuration).GetCustomersCore(
                new Customer.LibraryCore.ServiceReferenceCore.CustomerCore()
                {
                    CustomerName = customerName
                }
            ).Result;
            if (customersResult != null && customersResult != null)
            {
                customers = customersResult;
            }
            return customers;
        }
    }
}
