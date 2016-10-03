using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Pracice1002.filter
{
    public class ViewBagFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
            base.OnActionExecuting(filterContext);
        }
        
    }
}