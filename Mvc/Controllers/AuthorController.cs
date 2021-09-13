using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager();
        AuthorManager authorManager = new AuthorManager();
        public PartialViewResult AuthorAbout(int id)
        {

            var authorAbout = bm.GetBlogById(id);
            return PartialView(authorAbout);
        }
        public PartialViewResult AuthorPopularPost(int id)
        {
            var BlogAuthorId = bm.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            var authorblogs = bm.GetBlogByAuthor(BlogAuthorId);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists = authorManager.GetAll();
            return View(authorlists);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            authorManager.AddAuthorBL(author);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.FindAuthor(id);
            return View(author);
            
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            authorManager.EditAuthor(author);
            return RedirectToAction("AuthorList");
        }
    }
}