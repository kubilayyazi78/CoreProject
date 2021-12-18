using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        private Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = _context.Blogs.OrderByDescending(x => x.Id).Select(x => x.Title).Take(1)
                .FirstOrDefault();
            ViewBag.CommentCount = _context.Comments.Count();
            return View();
        }
    }
}
