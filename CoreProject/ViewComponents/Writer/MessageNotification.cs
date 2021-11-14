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
        private MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string mail = "belo@hot.com";
            var values = _messageManager.GetInboxListByWriter(mail);
            return View(values);
        }
    }
}
