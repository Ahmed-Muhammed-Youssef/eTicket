using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Models;

namespace mvc.Controllers
{
    [Authorize(Roles = UserRolesValues.Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(u => new UserVM() 
            { 
                Id = u.Id,
                Email = u.Email ?? "-",
                FullName = u.GetFullName(),
                UserName = u.UserName ?? "-",
                PhoneNumber = u.PhoneNumber ?? "-"
            
            }).ToListAsync();
            if (users is null)
            {
                users = new List<UserVM>();
            }
            return View(users);
        }
    }
}
