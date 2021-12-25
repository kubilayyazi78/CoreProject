using CoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Name = "Teknoloji",
                Count = 10
            });
            categories.Add(new Category
            {
                Name = "Yazılım",
                Count = 15
            });
            categories.Add(new Category
            {
                Name = "Spor",
                Count = 20

            });

            return Json((new { jsonList = categories }));
        }
    }
}
