using Customer.APICore;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;
using CustomerServiceCoreProxy;

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
        public IEnumerable<CustomerServiceCoreProxy.CustomerCore> Get(string? customerName)
        {
            List<CustomerServiceCoreProxy.CustomerCore> customers = new List<CustomerServiceCoreProxy.CustomerCore>();

            var customersResult = new CustomerCores(_configuration).GetCustomersCore(
                new CustomerServiceCoreProxy.CustomerCore()
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
