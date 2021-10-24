﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    //[Authorize]
    public class WriterController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

    }
}