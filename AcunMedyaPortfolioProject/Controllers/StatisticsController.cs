using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult StatisticTable()

        {
            var totalProjects = db.Projects.Count();
            var totalExperiences = db.Experiences.Count();
            var totalTestimonials = db.Testimonials.Count();

            ViewBag.Totalprojects = totalProjects;
            ViewBag.TotalExperiences = totalExperiences;
            ViewBag.TotalTestimonials = totalTestimonials;

            return View();
        }
    }
}