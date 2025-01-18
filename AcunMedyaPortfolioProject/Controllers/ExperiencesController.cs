using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult ExperienceTable()
        {
            var ExperienceTable = db.Experiences.ToList();
            return View(ExperienceTable);
        }
        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExperience(Experiences experiences)
        {
            db.Experiences.Add(experiences);
            db.SaveChanges();
            return RedirectToAction("ExperienceTable");
        }
        public ActionResult DeleteExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("ExperienceTable");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experiences experiences)
        {
            var updatedExperience = db.Experiences.Find(experiences.Id);
            updatedExperience.Tıtle = experiences.Tıtle;
            updatedExperience.CompanyName = experiences.CompanyName;
            updatedExperience.StartDate = experiences.StartDate;
            updatedExperience.EndDate = experiences.EndDate;
            updatedExperience.Description = experiences.Description;
            db.SaveChanges();
            return RedirectToAction("ExperienceTable");
        }
    }
}