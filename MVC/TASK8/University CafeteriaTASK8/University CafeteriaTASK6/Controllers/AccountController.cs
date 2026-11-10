using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Regester()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Regester(Regester regester)
        {
            var user = new IdentityUser
            {
                UserName = regester.Name,
                Email = regester.Email,
            };
            var result = await _userManager.CreateAsync(user, regester.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(user, "User");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();



        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(login);
            }
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(login);
        }
        [HttpPost]
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
