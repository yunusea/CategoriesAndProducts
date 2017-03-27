using MVCUI.Context;
using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class ProductController : Controller
    {
        ProjectDbContext dbContext = new ProjectDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProduct()
        {
            var allProducts = dbContext.Products.ToList();
            return Json(allProducts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddProduct(Products products)
        {
            try
            {
                products.CategoryID = products.CategoryID;
                products.PriceVat = products.Price * 1.18;
                dbContext.Products.Add(products);
                dbContext.SaveChanges();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public JsonResult GetProduct(int Id)
        {
            try
            {
                var getProduct = dbContext.Products.Find(Id);
                return Json(getProduct, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public JsonResult UpdateProduct(Products products)
        {
            try
            {
                var data = dbContext.Products.First(x => x.ProductID == products.ProductID);
                data.CategoryID = products.CategoryID;
                data.ProductName = products.ProductName;
                data.UnitInStock = products.UnitInStock;
                data.Price = products.Price;
                data.PriceVat = products.Price * 1.18;

                dbContext.SaveChanges();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public ActionResult DeleteProduct(int Id)
        {
            try
            {
                var data = dbContext.Products.First(x => x.ProductID == Id);
                dbContext.Products.Remove(data);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }
    }
}