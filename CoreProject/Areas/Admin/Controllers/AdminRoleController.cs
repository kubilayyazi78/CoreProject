using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Areas.Admin.Models;
using CoreProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace CoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = roleViewModel.Name
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(roleViewModel);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel roleUpdateViewModel = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name

            };
            return View(roleUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel roleUpdateViewModel)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleUpdateViewModel.Id);
            values.Name = roleUpdateViewModel.Name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {

                return RedirectToAction("Index");
            }

            return View(roleUpdateViewModel);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            foreach (var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.RoleId = item.Id;
                roleAssignViewModel.Name = item.Name;
                roleAssignViewModel.Exists = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(roleAssignViewModel);
            }

            return View(roleAssignViewModels);
        }
    }
}
