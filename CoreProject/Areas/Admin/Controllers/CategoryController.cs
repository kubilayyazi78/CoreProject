using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using X.PagedList;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page =1)
        {
            var values = _categoryManager.GetList().ToPagedList(page,3);
            return View(values);
        }
    }
}
