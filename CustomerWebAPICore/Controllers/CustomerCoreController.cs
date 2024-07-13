using Customer.APICore;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerCoreController : ControllerBase
    {        
        private readonly ILogger<CustomerController> _logger;
        private ICustomersCore _customersCore;      

        public CustomerCoreController(ICustomersCore customersCore, ILogger<CustomerController> logger)
        {
            this._customersCore = customersCore;            
            _logger = logger;
        }       

        [HttpGet(Name = "CustomerCore")]
        public IEnumerable<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> Get(string? customerName)
        {
            List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> customers = new List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>();

            var customersResult = _customersCore.GetCustomersCore(
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
