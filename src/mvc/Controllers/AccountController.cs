﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Models;
using System.Configuration;

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
        public IActionResult Login() => View(new LoginVM());

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

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var u = await _userManager.FindByEmailAsync(registerVM.Email);
            if(u != null)
            {
                TempData["Error"] = "This email is already taken";
                return View(registerVM);
            }
            var user = new AppUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                EmailConfirmed = true,
            };
            var res = await _userManager.CreateAsync(user, registerVM.Password);
            if(!res.Succeeded)
            {
                TempData["Error"] = string.Join("\n", res.Errors.Select(e=>e.Description));
                return View(registerVM);
            }
            var roleAssignRes = await _userManager.AddToRoleAsync(user, UserRolesValues.User);
            if(!roleAssignRes.Succeeded) 
            {
                TempData["Error"] = string.Join(" - ", roleAssignRes.Errors.Select(e => e.Description));
                return View(registerVM);
            }
            return View("RegisterCompleted");
        }

    }
}
