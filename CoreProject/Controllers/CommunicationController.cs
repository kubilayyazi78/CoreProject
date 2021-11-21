using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    [AllowAnonymous]
    public class CommunicationController : Controller
    {
        private CommunicationManager _communicationManager = new CommunicationManager(new EfCommunicationRepository());
        public IActionResult Inbox()
        {
            var values = _communicationManager.GetInboxListByWriter(2);
            return View(values);
        }

        public IActionResult Details(int id)
        {
            var values = _communicationManager.GetById(id);
            return View(values);
        }
    }
}
