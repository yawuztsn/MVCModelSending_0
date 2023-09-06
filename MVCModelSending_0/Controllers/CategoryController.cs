using MVCModelSending_0.DesignPatterns.SingletonPattern;
using MVCModelSending_0.Models;
using MVCModelSending_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCModelSending_0.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DbInstance;
        }
        public ActionResult ListCategories()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _db.Categories.ToList(),
                Employees = _db.Employees.ToList()
                
            };
            return View(cvm);
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory([Bind(Prefix ="Category")]Category c)
        {
            _db.Categories.Add(c);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _db.Categories.Find(id)
            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            Category toBeUpdated = _db.Categories.Find(category.CategoryID);
            toBeUpdated.CategoryName = category.CategoryName;
            toBeUpdated.Description = category.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

    }
}