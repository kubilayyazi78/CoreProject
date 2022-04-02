using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = _commentManager.GetListWithBlog();
            return View(values);
        }
    }
}
