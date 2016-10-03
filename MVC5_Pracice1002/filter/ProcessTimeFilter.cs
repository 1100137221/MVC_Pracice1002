using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Pracice1002.filter
{
    public class ProcessTimeFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            TimeSpan exectuionTime = TimeSpan.FromHours(1);
            filterContext.Controller.ViewBag.ProcessTime = exectuionTime;

            base.OnActionExecuted(filterContext);
        }

    }
}