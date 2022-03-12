using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.UserName = userName;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = _writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
