using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC5_Pracice1002.Models;

namespace MVC5_Pracice1002.Controllers
{
    public class VRController : Controller
    {
        // GET: VR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            return Content("<script>alert('msg...')</script>", "application/javascript", Encoding.UTF8);
        }

        public ActionResult FileTest()
        {
            return File(Server.MapPath(""), "image/png", "GoGo.png");
        }

        public ActionResult JsonTest()
        {
            var db = new FabricsEntities();

            db.Configuration.LazyLoadingEnabled = false;

            return Json(db.Product.Take(5), JsonRequestBehavior.AllowGet);

        }

    }
}