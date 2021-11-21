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
            ViewBag.Count = _context.Blogs.Count().ToString();
            ViewBag.WriterCount = _context.Blogs.Count(x => x.WriterId == 1).ToString();
            ViewBag.CategoryCount = _context.Categories.Count().ToString();
            return View();
        }
    }
}
