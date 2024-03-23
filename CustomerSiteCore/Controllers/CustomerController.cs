using CustomerSiteCore.Controllers;
using CustomerSiteCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace CustomerSiteCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CustomerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CustomerModel();
            model.CustomerName = ""; // initial search query

            return View(model);
        }
        //public ActionResult Index()
        //{
        //    var model = new CustomerModel();
        //    return View(model);
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}