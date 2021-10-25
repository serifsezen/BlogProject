using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BlogManager blogManager = new BlogManager();
        // GET: User

        UserProfileManager userProfile = new UserProfileManager();
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult partial1(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }



        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.Mail == p).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c = new Context();
            //adminpaneli kategoriler DropDown
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in c.Categories.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            ViewBag.kategoriler = kategoriler;

            //adminpaneli yazarlar DropDown
            List<SelectListItem> yazarlar = new List<SelectListItem>();
            foreach (var item in c.Authors.ToList())
            {
                yazarlar.Add(new SelectListItem { Text = item.AuthorName, Value = item.AuthorId.ToString() });
            }
            ViewBag.yazarlar = yazarlar;
            Blog blog = blogManager.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.BlogUpdate(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            //adminpaneli kategoriler DropDown
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in c.Categories.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }
            ViewBag.kategoriler = kategoriler;

            //adminpaneli yazarlar DropDown
            List<SelectListItem> yazarlar = new List<SelectListItem>();
            foreach (var item in c.Authors.ToList())
            {
                yazarlar.Add(new SelectListItem { Text = item.AuthorName, Value = item.AuthorId.ToString() });
            }
            ViewBag.yazarlar = yazarlar;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.BlogAdd(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}