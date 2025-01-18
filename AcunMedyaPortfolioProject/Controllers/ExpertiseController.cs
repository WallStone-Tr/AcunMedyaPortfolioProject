using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ExpertiseController : Controller
    {
        // GET: Expertise
        PortfolyoDBEntities db= new PortfolyoDBEntities();
        public ActionResult ExpertiseTable()
        {
            var ExpertiseTable = db.Expertise.ToList();
            return View(ExpertiseTable);
        }
        [HttpGet]
        public ActionResult CreateExpertise()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExpertise(Expertise expertise)
        {
            db.Expertise.Add(expertise);
            db.SaveChanges();
            return RedirectToAction("ExpertiseTable");
        }
        public ActionResult DeleteExpertise(int id)
        {
            var expertise = db.Expertise.Find(id);
            db.Expertise.Remove(expertise);
            db.SaveChanges();
            return RedirectToAction("ExpertiseTable");
        }
        [HttpGet]
        public ActionResult UpdateExpertise(int id)
        {
            var expertise = db.Expertise.Find(id);
            return View(expertise);
        }
        [HttpPost]
        public ActionResult UpdateExpertise(Expertise expertise)
        {
            var updatedExpertise = db.Expertise.Find(expertise.Id);
            updatedExpertise.Text = expertise.Text;
            db.SaveChanges();
            return RedirectToAction("ExpertiseTable");
        }
    }
}