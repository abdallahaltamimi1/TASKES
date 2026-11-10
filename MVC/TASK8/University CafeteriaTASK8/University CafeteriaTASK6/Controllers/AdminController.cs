using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace University_CafeteriaTASK6.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
           ViewBag.rolwManeger= _roleManager.Roles.ToList();

            return View(users);
           
        }
        [HttpGet]
        
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = _roleManager.Roles.ToList();

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            string[] allowedRoles =
            {
                "User", "Admin", "SuperAdmin"
            };

            if (!allowedRoles.Contains(roleName) ||
                !await _roleManager.RoleExistsAsync(roleName))
            {
                return BadRequest("Invalid role");
            }

            var currentRoles =
                await _userManager.GetRolesAsync(user);

            // Prevent removing the last SuperAdmin
            if (currentRoles.Contains("SuperAdmin") &&
                roleName != "SuperAdmin")
            {
                var superAdmins =
                    await _userManager.GetUsersInRoleAsync("SuperAdmin");

                if (superAdmins.Count <= 1)
                {
                    return BadRequest(
                        "Cannot remove the last SuperAdmin");
                }
            }

            if (currentRoles.Count == 1 &&
                currentRoles.Contains(roleName))
            {
                return RedirectToAction("Index");
            }

            var removeResult =
                await _userManager.RemoveFromRolesAsync(
                    user, currentRoles);

            if (!removeResult.Succeeded)
            {
                return BadRequest(removeResult.Errors);
            }

            var addResult =
                await _userManager.AddToRoleAsync(user, roleName);

            if (!addResult.Succeeded)
            {
                // Try to restore the previous roles
                await _userManager.RemoveFromRoleAsync(
                    user, roleName);

                await _userManager.AddToRolesAsync(
                    user, currentRoles);

                return BadRequest(addResult.Errors);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("SuperAdmin"))
            {
                return BadRequest(
                    "Cannot delete a SuperAdmin account");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return RedirectToAction("Index");
        }
    }
}
