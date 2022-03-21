using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{

    public class CommunicationController : Controller
    {
        private CommunicationManager _communicationManager = new CommunicationManager(new EfCommunicationRepository());
        private Context _context = new Context();
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = _communicationManager.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult Details(int id)
        {
            var values = _communicationManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Communication communication)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            communication.SenderId = writerId;
            communication.ReceiverId = 2;
            communication.Status = true;
            communication.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _communicationManager.Add(communication);
            return RedirectToAction("Inbox");
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
    }
}
