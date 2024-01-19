using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;

namespace ZunezxShop_Web.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index()
        {
            var items = dbConnect.Posts.ToList();
            return View(items);
        }
    }
}