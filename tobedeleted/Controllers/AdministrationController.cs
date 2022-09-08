using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;


namespace tobedeleted.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

       

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                         UserManager<IdentityUser>userManager) 
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            ViewBag.UserName = user.UserName;

            var userRoles = await userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return RedirectToAction(nameof(DisplayRoles));
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(string role)
        {


            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));

            //var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
            //if (!roleExist)
            //{
            //    var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
            //}
            //return View();
        }
        [HttpGet]
        public IActionResult DisplayRoles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRole userRole )
        {
            var user = await userManager.FindByIdAsync(userRole.UserId);

            await userManager.AddToRoleAsync(user, userRole.RoleName);

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string role,string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            var result = await userManager.RemoveFromRoleAsync(user,role);

            return RedirectToAction(nameof(Details), new { userId = user.Id });
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRole(string role)
        {
            var roleToDelete = await userManager.FindByNameAsync(role);
            var result = await userManager.DeleteAsync(roleToDelete);
            return RedirectToAction(nameof(DisplayRoles));
        }


    }
}
