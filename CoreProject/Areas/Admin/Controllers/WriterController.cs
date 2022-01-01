using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Areas.Admin.Models;
using Newtonsoft.Json;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(Writers);
            return Json(jsonWriters);
        }

        public List<WriterModel> Writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id = 1,
                Name = "Ahmet"
            },
            new WriterModel
            {
                Id = 2,
                Name = "Veli"
            },
            new WriterModel
            {
                Id = 3,
                Name = "Mehmet"
            }
        };
    }
}
