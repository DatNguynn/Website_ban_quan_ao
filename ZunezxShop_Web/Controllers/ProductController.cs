using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;

namespace ZunezxShop_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var items = dbConnect.Products.ToList();
            var valueSearch = Request.QueryString["valueSearch"];
            if (!string.IsNullOrEmpty(valueSearch))
            {
                items = Search(items, valueSearch);
            }

            int itemsPerPage = 10;
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

        public List<Tb_Product> Search(List<Tb_Product> products, string searchText)
        {
            products = dbConnect.Products.Include(x => x.ProductCategory).ToList();
            ViewBag.ProductCategory = dbConnect.ProductCategories.ToList();
            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.FindAll(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText) || x.ProductCategory.Title.Contains(searchText));
            }
            return products;
        }

        public ActionResult Detail(string alias, int id)
        {
            var item = dbConnect.Products.Find(id);
            return View(item);
        }

        public ActionResult ProductCategory(string alias, int id)
        {
            var items = dbConnect.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = dbConnect.ProductCategories.Find(id);
            if(cate != null)
            {
                ViewBag.CateName = cate.Title;
            }    
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = dbConnect.Products.Where(x=>x.IsHome && x.IsActive).Take(30).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ProductIsHot()
        {
            var items = dbConnect.Products.Where(x => x.IsHot && x.IsActive).Take(15).ToList();
            return PartialView(items);
        }
    }
}