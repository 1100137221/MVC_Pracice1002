using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Pracice1002.Models;

namespace MVC5_Pracice1002.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();

            db.Product.Add(new Product() {
                ProductName = "BMW",
                Price = 5,
                Stock = 1,
                Active = true
            });

            db.SaveChanges();

            return View(db.Product.ToList());
        }
    }
}