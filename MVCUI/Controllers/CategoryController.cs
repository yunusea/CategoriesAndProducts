using MVCUI.Context;
using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class CategoryController : Controller
    {
        ProjectDbContext dbContext = new ProjectDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCategory()
        {
            var allCategories = dbContext.Categories.ToList().OrderBy(x => x.Order);
            return Json(allCategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCategory(Categories categories)
        {
            try
            {
                dbContext.Categories.Add(categories);
                dbContext.SaveChanges();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public JsonResult GetCategory(int Id)
        {
            try
            {
                var getCategory = dbContext.Categories.Find(Id);
                return Json(getCategory, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public JsonResult UpdateCategory(Categories categories)
        {
            try
            {
                var data = dbContext.Categories.First(x => x.CategoryID == categories.CategoryID);
                data.CategoryName = categories.CategoryName;
                data.Order = categories.Order;
                data.IsActive = categories.IsActive;
                dbContext.SaveChanges();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }

        public ActionResult DeleteCategory(int Id)
        {
            try
            {
                var data = dbContext.Categories.First(x => x.CategoryID == Id);
                dbContext.Categories.Remove(data);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Opps !", ex);
            }
        }
    }
}