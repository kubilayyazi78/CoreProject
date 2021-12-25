using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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

            string api = "4c0d8e3843a5fe34e8a9f96bdac3b797";
            string connection =
                "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr%units=metric&appid=" + api;
            XDocument document=XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
