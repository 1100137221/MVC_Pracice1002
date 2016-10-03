using MVC5_Pracice1002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Pracice1002.filter;

namespace MVC5_Pracice1002.Controllers
{
    [ProcessTimeFilter]
    public class HomeController : Controller
    {
        [ViewBagFilter]
        public ActionResult Index()
        {
            return View();
        }

        [ViewBagFilter]
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult MemberProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
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