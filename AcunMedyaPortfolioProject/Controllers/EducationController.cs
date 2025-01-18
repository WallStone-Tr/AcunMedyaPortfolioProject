using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult EducationTable()
        {
            var EducationTable = db.Educations.ToList();
            return View(EducationTable);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Educations educations)
        {
            db.Educations.Add(educations);
            db.SaveChanges();
            return RedirectToAction("EducationTable");
        }
        public ActionResult DeleteEducation(int id)
        {
            var education = db.Educations.Find(id);
            db.Educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("EducationTable");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = db.Educations.Find(id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Educations education)
        {
            var updatedEducation = db.Educations.Find(education.Id);
            updatedEducation.Title = education.Title;
            updatedEducation.InstutionName = education.InstutionName;
            updatedEducation.StartDate = education.StartDate;
            updatedEducation.EndDate = education.EndDate;
            updatedEducation.Description = education.Description;
            db.SaveChanges();
            return RedirectToAction("EducationTable");
        }
    }
}