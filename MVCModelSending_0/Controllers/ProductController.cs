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
    public class ProductController : Controller
    {
        NorthwindEntities _db;
        public ProductController()
        {
            _db = DBTool.DbInstance;
        }

        public ActionResult ListProducts()
        {
            ProductVM pvm = new ProductVM()
            {
                Products = _db.Products.ToList()
            };
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Product = _db.Products.Find(id),
                Categories= _db.Categories.ToList()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            Product toBeUpdated = _db.Products.Find(product.ProductID);
            toBeUpdated.ProductName = product.ProductName;
            toBeUpdated.UnitPrice = product.UnitPrice;
            toBeUpdated.CategoryID = product.CategoryID;
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }
    }
}