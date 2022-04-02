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
    public class AdminBlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var values = _blogManager.GetListWithCategory();
            return View(values);
        }
    }
}
