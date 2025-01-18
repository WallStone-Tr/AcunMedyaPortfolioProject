using AcunMedyaPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();

            return View(projects);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            var categories = db.Catogories.ToList();
            var list = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = list;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Projects project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.Projects.Find(id);
            db.Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var project = db.Projects.Find(id);
            var categories = db.Catogories.ToList();
            var list = new SelectList(categories, "Id", "Name", project.CategoryId);
            ViewBag.Categories = list;
            return View(project);
        }
        [HttpPost]
        public ActionResult UpdateProject(Projects project)
        {
            var updatedProject = db.Projects.Find(project.Id);
            updatedProject.Name = project.Name;
            updatedProject.CategoryId = project.CategoryId;
            updatedProject.CoverImageUrl = project.CoverImageUrl;
            updatedProject.Description = project.Description;
            updatedProject.ProjectLink = project.ProjectLink;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}