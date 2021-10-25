using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager();
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {

            var BlogListe = blogManager.GetAll().ToPagedList(page, 6);
            return PartialView(BlogListe);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //Post1
            var PostTitle1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            var PostId1 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostTitle1 = PostTitle1;
            ViewBag.PostImage1 = PostImage1;
            ViewBag.PostDate1 = PostDate1;
            ViewBag.PostId1 = PostId1;

            //Post2
            var PostTitle2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            var PostId2 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostTitle2 = PostTitle2;
            ViewBag.PostImage2 = PostImage2;
            ViewBag.PostDate2 = PostDate2;
            ViewBag.PostId2 = PostId2;

            //Post3
            var PostTitle3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            var PostId3 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostTitle3 = PostTitle3;
            ViewBag.PostImage3 = PostImage3;
            ViewBag.PostDate3 = PostDate3;
            ViewBag.PostId3 = PostId3;

            //Post4
            var PostTitle4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            var PostId4 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostTitle4 = PostTitle4;
            ViewBag.PostImage4 = PostImage4;
            ViewBag.PostDate4 = PostDate4;
            ViewBag.PostId4 = PostId4;

            //Post5
            var PostTitle5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            var PostId5 = blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostTitle5 = PostTitle5;
            ViewBag.PostImage5 = PostImage5;
            ViewBag.PostDate5 = PostDate5;
            ViewBag.PostId5 = PostId5;
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var CategoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDesc = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;

            var BlogListByCategory = blogManager.GetBlogByCategory(id);
            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var BlogListe = blogManager.GetAll();
            return View(BlogListe);
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            blogManager.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager commentManager = new CommentManager();
            var commentlist = commentManager.GetCommentById(id);
            return View(commentlist);

        }
    }
}