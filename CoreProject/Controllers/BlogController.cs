using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProject.Controllers
{

    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        private Context _context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogManager.GetListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = _blogManager.GetListWithCategoryByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.Category = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var blogValue = _blogManager.GetById(id);
            _blogManager.Delete(blogValue);

            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.Category = categoryValues;
            var blogValue = _blogManager.GetById(id);
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            blog.WriterId = writerId;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
