using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class IntroductionController : Controller
    {
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        // GET: Introduction
        
        public ActionResult IntroductionTable()
        {
            var introduction = db.İntrodiction.ToList();
            return View(introduction);
        }
        [HttpGet]
        public ActionResult CreateIntroduction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateIntroduction(İntrodiction introduction)
        {
            db.İntrodiction.Add(introduction);
            db.SaveChanges();
            return RedirectToAction("IntroductionTable");
        }
        public ActionResult DeleteIntroduction(int id)
        {
            var introduction = db.İntrodiction.Find(id);
            db.İntrodiction.Remove(introduction);
            db.SaveChanges();
            return RedirectToAction("IntroductionTable");
        }
        [HttpGet]
        public ActionResult UpdateIntroduction(int id)
        {
            var introduction = db.İntrodiction.Find(id);
            return View(introduction);
        }
        [HttpPost]
        public ActionResult UpdateIntroduction(İntrodiction introduction)
        {
            var updatedIntroduction = db.İntrodiction.Find(introduction.Id);
            updatedIntroduction.Title = introduction.Title;
            updatedIntroduction.Description = introduction.Description;
            db.SaveChanges();
            return RedirectToAction("IntroductionTable");

        }

    }
}