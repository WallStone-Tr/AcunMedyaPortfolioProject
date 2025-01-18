using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class TestimonialsController : Controller
    {
        // GET: Testimonials
        PortfolyoDBEntities db=new PortfolyoDBEntities();
        public ActionResult TestimonialTable()
        {
            var TestimonialTable = db.Testimonials.ToList();
            return View(TestimonialTable);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonials testimonial)
        {
            db.Testimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialTable");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.Testimonials.Find(id);
            db.Testimonials.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialTable");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.Testimonials.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonials testimonial)
        {
            var updatedTestimonial = db.Testimonials.Find(testimonial.Id);
            updatedTestimonial.NameSurname = testimonial.NameSurname;
            updatedTestimonial.Title = testimonial.Title;
            updatedTestimonial.ImageUrl = testimonial.ImageUrl;
            updatedTestimonial.Comment = testimonial.Comment;
            db.SaveChanges();
            return RedirectToAction("TestimonialTable");
        }
    }
}