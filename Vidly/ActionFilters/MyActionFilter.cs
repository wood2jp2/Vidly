using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace Vidly.ActionFilters
{
    public class MyActionFilter : ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var currentUser = !String.IsNullOrWhiteSpace(filterContext.HttpContext.User.Identity.Name) ? filterContext.HttpContext.User.Identity.Name : "Anonymous";
            var requestToUrl = filterContext.HttpContext.Request.Url;
            var requestType = filterContext.HttpContext.Request.RequestType;
            var currentSessionTimeout = DateTime.Now.AddMinutes(1).ToLongTimeString();

            filterContext.HttpContext.Items["user"] = currentUser;
            filterContext.HttpContext.Items["expiryTime"] = currentSessionTimeout;

            base.OnActionExecuting(filterContext);

            //StreamWriter obj = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            //obj.Write("Username: " + currentUser + " made a" + requestType + " request to " + requestToUrl + " on " + DateTime.Now + ". Session set to expire " + currentSessionTimeout + Environment.NewLine);
            //obj.Close();

        }
    }
}