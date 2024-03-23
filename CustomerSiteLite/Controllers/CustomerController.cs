using CustomerSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerSite.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var model = new CustomerModel();
            model.CustomerName = ""; // initial search

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}