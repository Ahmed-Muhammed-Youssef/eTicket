using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.ViewModels;
using mvc.Models;

namespace mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _dbContext;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, AppDbContext dbContext)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: Account/Login
        public IActionResult Login()
        {
            var loginVm = new LoginVM();
            return View(loginVm);
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);   
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if(user == null)
            {
                TempData["Error"] = "Wrong credentials. Please try again.";
                return View(loginVM);
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if(passwordCheck == false)
            {
                TempData["Error"] = "Wrong credentials. Please try again.";
                return View(loginVM);
            }
            var loginRes = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if(!loginRes.Succeeded)
            {
                TempData["Error"] = "Wrong credentials. Please try again.";
                return View(loginVM);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Movies");
        }

        // only signed-in useres should have access to this method

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
