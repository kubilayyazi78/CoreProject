using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        private Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = _context.Admins.Where(x => x.Id == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.Image = _context.Admins.Where(x => x.Id == 1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.Desc = _context.Admins.Where(x => x.Id == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
