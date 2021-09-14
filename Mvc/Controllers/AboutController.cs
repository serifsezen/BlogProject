using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager();
        // GET: About
        public ActionResult Index()
        {
            return View(aboutManager.GetAll());
        }
        public PartialViewResult Footer()
        {

            return PartialView(aboutManager.GetAll());
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager authorManager = new AuthorManager();
            var authorList = authorManager.GetAll();
            return PartialView(authorList);
        }
        public ActionResult UpdateAboutList()
        {
            var aboutlist = aboutManager.GetAll();
            return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            aboutManager.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}