using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using Vidly.ActionFilters;
using System.Web.SessionState;
using System.IO;

namespace Vidly.Controllers
{
    [MyActionFilter]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.WriteLine(HttpContext.Items["user"]);
            var sessionExpiryTime = HttpContext.Items["expiryTime"];
            if (Request.IsAuthenticated)
            {
                Debug.WriteLine("There is an authenticated user: " +  HttpContext.Items["user"] + " with a session expiration of " + sessionExpiryTime);
            } else
            {
                Debug.WriteLine("there is NOT an authenticated user");
            }

            ViewBag.sessionExpiryTime = sessionExpiryTime;
            System.Web.HttpContext.Current.Session.Timeout = 1;
            
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