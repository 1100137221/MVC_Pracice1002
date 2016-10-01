using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Pracice1002.Models;
using System.Data.Entity.Validation;

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

           
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;
                    
                    foreach(DbValidationError err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " 驗證失敗:" + err.ErrorMessage);
                    }

                }
                throw new Exception(" 驗證失敗:");
            }


            return View(db.Product.ToList());
        }
    }
}