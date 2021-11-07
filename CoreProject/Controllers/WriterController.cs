using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProject.Models;
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValue = _writerManager.GetById(1);
            return View(writerValue);
        }

        [AllowAnonymous]
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
