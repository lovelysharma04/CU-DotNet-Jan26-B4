using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarManagementMVCApp.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CarManagementMVCApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            var model = new List<UserRolesViewModel>();

            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u);
                model.Add(new UserRolesViewModel
                {
                    UserId = u.Id,
                    Email = u.Email,
                    Roles = roles
                });
            }

            return View(model);
        }
    }
}
