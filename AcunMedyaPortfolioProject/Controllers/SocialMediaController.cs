using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfoliaProject.Controllers
{
    public class SocialMediaController : Controller
    {
        PortfolyoDBEntities db=new PortfolyoDBEntities();
        public ActionResult SocialMediaTable()
        {
            var socialMedia = db.SocialMedia.ToList();
            return View(socialMedia);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            db.SocialMedia.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("SocialMediaTable");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = db.SocialMedia.Find(id);
            db.SocialMedia.Remove(socialMedia);
            db.SaveChanges();
            return RedirectToAction("SocialMediaTable");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = db.SocialMedia.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var updatedSocial = db.SocialMedia.Find(socialMedia.Id);
            updatedSocial.Platform = socialMedia.Platform;
            updatedSocial.Link = socialMedia.Link;
            db.SaveChanges();
            return RedirectToAction("SocialMediaTable");
        }
    }
}