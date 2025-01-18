using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolioProject.Models;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        PortfolyoDBEntities db = new PortfolyoDBEntities();
        public ActionResult ContactTable()
        {
            var ContactTable = db.Contact.ToList();
            return View(ContactTable);
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("ContactTable");
        }
        public ActionResult DeleteContact(int id)
        {
            var contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("ContactTable");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.Contact.Find(id);
            return View(contact);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var updatedContact = db.Contact.Find(contact.Id);
            updatedContact.Phone = contact.Phone;
            updatedContact.EmailAddress = contact.EmailAddress;
            updatedContact.Address = contact.Address;
            db.SaveChanges();
            return RedirectToAction("ContactTable");
        }
    }
}