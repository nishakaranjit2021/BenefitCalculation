using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefitsApp.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            string message;

            if (filterContext.Exception != null)
            {
                message = filterContext.Exception.Message;
            }
            else
            {
                message = "Unhandled exception in " + GetType().Name;
            }
            //We can add Log function here currenly I haven't created that yet for this demo project

            Server.Transfer("~/Error/500.html");
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}