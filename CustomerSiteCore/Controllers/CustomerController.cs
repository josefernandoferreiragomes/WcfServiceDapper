using Customer.APICore;
using CustomerSiteCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSiteCore.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomersCore _customersCore;
        //private readonly IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;       

        public CustomerController(ICustomersCore customersCore, ILogger<HomeController> logger)
        {
            _customersCore = customersCore;
          //  Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CustomerModel(_customersCore);
            model.CustomerName = ""; // initial search query

            return View(model);
        }
       
    }
}