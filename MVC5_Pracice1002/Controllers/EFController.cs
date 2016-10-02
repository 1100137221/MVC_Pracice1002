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
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            

            //db.Product.Add(new Product() {
            //    ProductName = "BMW",
            //    Price = 5,
            //    Stock = 1,
            //    Active = true
            //});
            
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(20);

            foreach (var item in data)
            {
                item.Price += 1;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;

                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " 驗證失敗:" + err.ErrorMessage);
                    }

                }
                throw new Exception(" 驗證失敗:");
            }

            return View(data);
        }

        public ActionResult Detail(int id)
        {
            var product = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            //先刪除明細(多筆)
            db.OrderLine.RemoveRange(product.OrderLine);
            //再刪除產品
            db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}