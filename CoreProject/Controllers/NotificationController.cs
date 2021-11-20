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
    public class NotificationController : Controller
    {
        private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = _notificationManager.GetList();

            return View(values);
        }
    }
}
