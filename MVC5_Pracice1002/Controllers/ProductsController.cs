using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5_Pracice1002.Models;


namespace MVC5_Pracice1002.Controllers
{
    public class ProductsController : BaseController
    {
        private FabricsEntities db = new FabricsEntities();
        ProductRepository repo = RepositoryHelper.ProductRepository();


        // GET: Products
        public ActionResult Index(int? ProductId, string type, bool? isActive,string keyword)
        {
            ViewBag.type = type;
            if (ProductId.HasValue)
            {
                ViewBag.SelectedProductId = ProductId.Value;
            }
            var data = repo.All().Take(5);
            if (isActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue && p.Active.Value == isActive.Value);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            var item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Value = "true",Text="有效" });
            item.Add(new SelectListItem() { Value = "false", Text = "無效" });
            ViewData["isActive"] = new SelectList(item, "Value", "Text");

            return View(data);

        }

        [HttpPost]
        public ActionResult Index(IList<ProductsVIewModel> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = repo.find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repo.All().Take(5));
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection form)
        {

            Product product = repo.find(id);

            if(TryUpdateModel<Product>(product,new string[] {
                 "ProductId","ProductName","Price","Active","Stock" }))
            {
                TempData["ProductsEditDoneMsg"] = "商品編輯成功";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
