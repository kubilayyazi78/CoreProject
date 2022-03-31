using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private Context _context = new Context();
        private CommunicationManager _communicationManager = new CommunicationManager(new EfCommunicationRepository());
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = _communicationManager.GetInboxListByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = _communicationManager.GetSendBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
