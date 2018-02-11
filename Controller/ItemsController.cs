using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {

      [HttpGet("/contacts")]
      public ActionResult Index()
      {
          List<Contact> allContacts = Contact.GetAll();
          return View(allContacts);
      }

      [HttpGet("/contacts/new")]
      public ActionResult CreateForm()
      {
          return View();
      }
      [HttpGet("/contacts/{id}")]
        public ActionResult Details(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
        }

      [HttpPost("/contacts")]
      public ActionResult Create()
      {
          Contact newContact = new Contact(Request.Form["new-contact"]);
          List<Contact> allContacts = Contact.GetAll();
          return View("Index", allContacts);
        }

        [HttpPost("/contacts/delete")]
        public ActionResult DeleteAll()
        {
            Contact.ClearAll();
            return View();
        }

    }
}
