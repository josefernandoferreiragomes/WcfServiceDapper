using CustomerSiteCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSiteCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;       

        public CustomerController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CustomerModel(Configuration);
            model.CustomerName = ""; // initial search query

            return View(model);
        }
       
    }
}