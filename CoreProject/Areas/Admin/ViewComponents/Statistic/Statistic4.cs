using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
