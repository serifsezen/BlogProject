using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            contactManager.ContactAdd(p);
            return View();
        }

        public ActionResult SendBox()
        {
            var messageList = contactManager.GetAll();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetContactDetails(id);
            return View(contact);
        }
    }
}