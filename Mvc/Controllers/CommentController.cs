using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager();
        // GET: Comment
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var cm = commentManager.GetCommentById(id);
            return PartialView(cm);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment p)
        {
            commentManager.CommentAdd(p);
            return PartialView();
        }

        //status değerinin true dan false güncellenmesi,
        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        //status değerinin False dan True güncellenmesi,
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }

        //Status değeri true olan yorumların listelenmesi
        public ActionResult AdminCommentListTrue()
        {
            var commentlist = commentManager.commentByStatusTrue();
            return View(commentlist);
        }

        //Status değeri False olan yorumların listelenmesi
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = commentManager.commentByStatusFalse();
            return View(commentlist);
        }
    }
}