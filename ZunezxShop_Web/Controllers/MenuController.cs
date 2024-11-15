﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;

namespace ZunezxShop_Web.Controllers
{
    public class MenuController : Controller
    {
        readonly ApplicationDbContext dbConnet = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTop()
        {
            var items = dbConnet.Categories.OrderBy(x=>x.Position).ToList();
            return PartialView("_MenuTop", items);
        }

        public ActionResult MenuProductCategory()
        {
            var items = dbConnet.ProductCategories.Take(3).ToList();
            return PartialView("_MenuProductCategory", items);
        }

        public ActionResult MenuLeft(int? id)
        {
            if(id != null)
            {
                ViewBag.CateId = id;
            }    
            var items = dbConnet.ProductCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = dbConnet.ProductCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }
    }
}