using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic : ViewComponent
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = _blogManager.GetList().Count();
            ViewBag.ContactCount = _context.Contacts.Count();
            ViewBag.CommentCount = _context.Comments.Count();
            return View();
        }
    }
}
