using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZunezxShop_Web.Models;
using ZunezxShop_Web.Models.EF;
using static CKFinder.Connector.CKFinderEvent;

namespace ZunezxShop_Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Nhân viên")]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        public ActionResult Index(string searchText, int? page)
        {
            IEnumerable<Tb_Product> items = dbConnect.Products.OrderByDescending(x => x.Id);

            var selectedCategoryOption = Request.QueryString["selectedCategoryOption"];
            var selectedOptionPrice = Request.QueryString["selectedOptionPrice"];
            var checkSale = Request.QueryString["checkSale"];

/*            items = dbConnect.Products.Include(x => x.ProductCategory).ToList();*/
            ViewBag.ProductCategory = dbConnect.ProductCategories.ToList();
            if(!string.IsNullOrEmpty(selectedCategoryOption))
            {
                items = items.Where(x => x.ProductCategory.Title.Contains(selectedCategoryOption));
            }  
            else if(!string.IsNullOrEmpty(selectedOptionPrice))
            {
                items = SearchProduct(items, selectedOptionPrice);
            }    
            else if(checkSale != null)
            {
                items = items.Where(x => x.IsSale == true);
            }    
            else if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText));
            }

            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page.Value) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public IEnumerable<Tb_Product> SearchProduct(IEnumerable<Tb_Product> products, string selectedOptionPrice)
        {
            /*if (!string.IsNullOrEmpty(selectedCategoryOption))
                products = products.Where(x => x.ProductCategory.Title.Contains(selectedCategoryOption));*/
            if (!string.IsNullOrEmpty(selectedOptionPrice))
            {
                var number = Convert.ToInt32(string.Join("", selectedOptionPrice.Split('-')[0].Trim().Split('.')));

                if (number == 0)
                {
                    products = products.Where(item => item.Price >= 0 && item.Price < 100000);
                }
                else if (number == 100000)
                {
                    products = products.Where(item => item.Price >= 100000 && item.Price < 300000);
                }
                else if (number == 300000)
                {
                    products = products.Where(item => item.Price >= 300000 && item.Price < 500000);
                }
                else if (number == 500000)
                {
                    products = products.Where(item => item.Price >= 500000 && item.Price < 1000000);

                }
                else if (number == 1000000)
                {
                    products = products.Where(item => item.Price >= 1000000);

                }
            }
            return products;
        }

        public ActionResult Add() 
        {
            ViewBag.ProductCategory = new SelectList(dbConnect.ProductCategories.ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Tb_Product model, List<string> Images, List<int> rDefault)
        {
            if(ModelState.IsValid)
            {
                if(Images != null && Images.Count > 0)
                {
                    for(int i=0; i<Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImage.Add(new tb_ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new tb_ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }    
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = ZunezxShop_Web.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Products.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(dbConnect.ProductCategories.ToList(), "Id", "Title");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(dbConnect.ProductCategories.ToList(), "Id", "Title");
            var item = dbConnect.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Product model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = ZunezxShop_Web.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Products.Attach(model);
                dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                dbConnect.Products.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isHome = item.IsHome });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsHot(int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                item.IsHot = !item.IsHot;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isHot = item.IsHot });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = dbConnect.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isSale = item.IsSale });
            }
            return Json(new { success = false });
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
                        var obj = dbConnect.Products.Find(Convert.ToInt32(item));
                        dbConnect.Products.Remove(obj);
                        dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}