using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using Vidly.ActionFilters;

namespace Vidly.Controllers
{
    [MyActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.WriteLine(HttpContext.Items["user"]);
            //Debug.WriteLine("CURRENT SESSION: " + System.Web.HttpContext.Current.Session);
            return View();
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