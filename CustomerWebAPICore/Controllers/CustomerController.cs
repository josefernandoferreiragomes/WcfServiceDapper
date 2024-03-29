using Customer.APICore;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

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
        public IEnumerable<ServiceReference.Customer> Get(string? customerName)
        {
            List<ServiceReference.Customer> customers = new List<ServiceReference.Customer>();

            var customersResult = new Customers(_configuration).GetCustomersCore(
                new ServiceReference.Customer()
                {
                    CustomerName = customerName
                }
            ).Result;
            if( customersResult != null && customersResult!=null)
            {
                customers = customersResult;
            }
            return customers;
        }
    }
}
