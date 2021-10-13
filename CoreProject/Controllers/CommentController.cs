using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace CoreProject.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.BlogId = 3;
            commentManager.Add(comment);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
