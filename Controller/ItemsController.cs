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
       string newName = (Request.Form["contact-name"]);
       string newPhone = (Request.Form["contact-phone"]);
       string newAddress = (Request.Form["contact-address"]);

       Contact newContact = new Contact(newName, newPhone, newAddress);

       return View("Index", newContact);
     }
       {
        [HttpPost("/contacts/delete")]
        public ActionResult DeleteAll()
        {
            Contact.ClearAll();
            return View();
        }

    }
  }
}
