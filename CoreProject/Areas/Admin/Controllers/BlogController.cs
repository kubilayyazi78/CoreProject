using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using CoreProject.Areas.Admin.Models;
using DataAccessLayer.Concrete;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.Name;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Calisma1.xlsx");
                }
            }

        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel { Id = 1, Name = "C#" },
                new BlogModel { Id = 2, Name = "Java" },
                new BlogModel { Id = 3, Name = "C++" }

            };
            return blogModels;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;

                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.Name;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Calisma1.xlsx");
                }
            }
        }

        public List<BlogExcelModel> BlogTitleList()
        {
            List<BlogExcelModel> blogExcelModels = new List<BlogExcelModel>();
            using (var context = new Context())
            {
                blogExcelModels = context.Blogs.Select(x => new BlogExcelModel
                {
                    Name = x.Title,
                    Id = x.Id
                }).ToList();
            }

            return blogExcelModels;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
