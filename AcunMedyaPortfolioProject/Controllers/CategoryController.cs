using AcunMedyaPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult CategoryList()
        {
            var categoryList = db.Catogories.ToList();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Catogories category)
        {
            db.Catogories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Catogories.Find(id);
            db.Catogories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = db.Catogories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Catogories category)
        {
            var updatedCategory = db.Catogories.Find(category.Id);
            updatedCategory.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}