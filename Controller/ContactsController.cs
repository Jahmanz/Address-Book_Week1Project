using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
          List<Contact> allContacts = Contact.GetAll();
          return View(allContacts);
      }

      [HttpGet("/new")]
      public ActionResult CreateForm()
      {
          return View();
      }
      [HttpGet("/{id}")]
        public ActionResult Details(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
        }

      [HttpPost("/")]
      public ActionResult Create()
      {
          Contact newContact = new Contact (Request.Form["contact-name"], Request.Form["contact-address"],Request.Form["contact-phone"]);
          List<Contact> allContacts = Contact.GetAll();
          return View("Index", allContacts);
        }

        [HttpPost("/delete")]
        public ActionResult DeleteAll()
        {
            Contact.ClearAll();
            return View();
        }

    }
  }
