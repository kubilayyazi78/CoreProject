using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentVal = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName = "Kubi"
                },
                new UserComment
                {
                    Id = 2,
                    UserName = "Alpi"
                },
                new UserComment
                {
                    Id = 3,
                    UserName = "Hüso"
                }
            };
            return View(commentVal);
        }
    }
}
