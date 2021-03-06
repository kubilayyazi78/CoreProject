using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    public class DashboardController : Controller
    {
        private Context _context = new Context();
    
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            ViewBag.Count = _context.Blogs.Count().ToString();
            ViewBag.WriterCount = _context.Blogs.Count(x => x.WriterId == writerId).ToString();
            ViewBag.CategoryCount = _context.Categories.Count().ToString();
            return View();
        }
    }
}
