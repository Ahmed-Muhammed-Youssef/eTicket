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
        public async Task<IActionResult> Details(string id)
        {
            var u = await _userManager.Users
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (u is null)
            {
                return View("NotFound");
            }
            var roles = await _userManager.GetRolesAsync(u);
            var userVM = new DetailedUserVM()
            {
                Id = u.Id,
                Email = u.Email ?? "-",
                FullName = u.GetFullName(),
                UserName = u.UserName ?? "-",
                PhoneNumber = u.PhoneNumber ?? "-",
                Orders = u.Orders,
                Cart = u.Cart,
                MoneyPaied = u.Orders.Aggregate(0M, (acc, cur) => acc + cur.GetTotalPrice(), acc => acc),
                Roles = roles.ToList()?? new List<string>()
            };
            return View(userVM);
        }
    }
}
