using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProject.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    //[Authorize]
    public class WriterController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private Context _context = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.User = userMail;
            var writerName = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Name).FirstOrDefault();
            ViewBag.Name = writerName;
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


        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var writerValue = _writerManager.GetById(writerId);
            return View(writerValue);
        }


        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View();
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();

            if (addProfileImage.Image != null)
            {
                var extension = Path.GetExtension(addProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.Image.CopyTo(stream);
                writer.Image = newImageName;
            }

            writer.Mail = addProfileImage.Mail;
            writer.Name = addProfileImage.Name;
            writer.Password = addProfileImage.Password;
            writer.Status = true;
            writer.About = addProfileImage.About;

            _writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }


    }
}
