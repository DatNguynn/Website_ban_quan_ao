using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;

namespace ZunezxShop_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Nhân viên")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.countOrder = dbConnect.Orders.ToList().Count();
            ViewBag.countUser = dbConnect.Users.ToList().Count();
            ViewBag.countNews = dbConnect.News.ToList().Count();
            ViewBag.countProduct = dbConnect.Products.ToList().Count();
            return View();
        }
    }
}