using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using static CKFinder.Connector.CKFinderEvent;

namespace ZunezxShop_Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int page = 1)
        {
            var items = dbConnect.News.ToList();
            int itemsPerPage = 5;
            int totalItems = items.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            page = Math.Max(1, Math.Min(page, totalPages));

            var startIndex = (page - 1) * itemsPerPage;
            var endIndex = Math.Min(startIndex + itemsPerPage - 1, totalItems - 1);

            if (startIndex < 0 || startIndex >= totalItems)
            {
                items = null;
            }
            else
            {
                items = items.GetRange(startIndex, endIndex - startIndex + 1);
            }

            ViewBag.currentPage = page;
            ViewBag.totalPages = totalPages;
            return View(items);
        }

        public ActionResult PartialNewsHome()
        {
            var items = dbConnect.News.Take(3).ToList();
            return PartialView(items);
        }

        public ActionResult Detail(int id) 
        {
            var item = dbConnect.News.Find(id);
            return View(item);
        }
    }
}