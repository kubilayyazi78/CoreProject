using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CoreProject.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer)
        {
            //todo refactoring

            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail && x.Password == writer.Password);
            if (dataValue != null)
            {
                HttpContext.Session.SetString("username", writer.Mail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }

        }

    }
}
