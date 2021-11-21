using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents.Writer
{
    public class MessageNotification : ViewComponent
    {
        private CommunicationManager _communicationManager = new CommunicationManager(new EfCommunicationRepository());
        public IViewComponentResult Invoke()
        {
            var values = _communicationManager.GetInboxListByWriter(1);
            return View(values);
        }
    }
}
