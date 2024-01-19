using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;

namespace ZunezxShop_Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(string searchText, int? page)
        {
            IEnumerable<Tb_Order> items = dbConnect.Orders.OrderByDescending(x => x.Id);
            var pageSize = 15;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Code.Contains(searchText) || x.CustomerName.Contains(searchText) || x.Phone.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page.Value) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult View(int id)
        {
            var item = dbConnect.Orders.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, int status)
        {
            var item = dbConnect.Orders.Find(id);
            if(item != null)
            {
                dbConnect.Orders.Attach(item);
                item.TypePayment = status;
                dbConnect.Entry(item).Property(x=>x.TypePayment).IsModified = true;
                dbConnect.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Fail", Success = false });
        }
    }
}