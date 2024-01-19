using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;

namespace ZunezxShop_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ApplicationDbContext dbConnet = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbConnet.Categories.ToList();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Tb_Category model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = ZunezxShop_Web.Models.Common.Filter.FilterChar(model.Title);
                dbConnet.Categories.Add(model);
                dbConnet.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbConnet.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Category model)
        {
            if (ModelState.IsValid)
            {
                dbConnet.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = ZunezxShop_Web.Models.Common.Filter.FilterChar(model.Title);
                dbConnet.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnet.Entry(model).Property(x => x.Description).IsModified = true;
                dbConnet.Entry(model).Property(x => x.Alias).IsModified = true;
                dbConnet.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                dbConnet.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                dbConnet.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                dbConnet.Entry(model).Property(x => x.Position).IsModified = true;
                dbConnet.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbConnet.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                dbConnet.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var item = dbConnet.Categories.Find(id);
            if(item != null)
            {
                /*var DeleteItem = dbConnet.Categories.Attach(item);*/
                dbConnet.Categories.Remove(item);
                dbConnet.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}