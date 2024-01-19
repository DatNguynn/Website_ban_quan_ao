using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;

namespace ZunezxShop_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Nhân viên")]
    public class ProductImageController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = dbConnect.ProductImages.Where(x=>x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            dbConnect.ProductImages.Add(new tb_ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            dbConnect.SaveChanges();
            return Json(new {success = true});
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.ProductImages.Find(id);
            dbConnect.ProductImages.Remove(item);
            dbConnect.SaveChanges();
            return Json(new {success = true});
        }

        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = dbConnect.ProductImages.Find(Convert.ToInt32(item));
                        dbConnect.ProductImages.Remove(obj);
                        dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}