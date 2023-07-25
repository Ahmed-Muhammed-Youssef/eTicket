using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;
using System.Security.Claims;

namespace mvc.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public OrdersController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }
        public async Task<IActionResult> List()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var orders = await _orderService.
                GetUserOrdersAsync(userId, userEmail);

            return View(orders == null? new List<Order>(): orders);
        }
        [Authorize(Roles = UserRolesValues.Admin)]
        public async Task<IActionResult> ListAll()
        {
            
            
            var orders = await _orderService.
                GetOrdersWithUsersAsync();

            return View(orders == null ? new List<Order>() : orders);
        }
        
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.GetUserCartAsync(userId, userEmail);
            if(cart == null)
            {
                cart = new Cart();
            }
            CartVM cartVM = new CartVM()
            {
                Cart = cart,
                Total = cart.GetTotalPrice()
            };
            return View(cartVM);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.AddMovieToCartAsync(id, userId, userEmail);
            if(cart == null)
            {
                return View("NotFound");
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            if(userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.RemoveMovieFromCartAsync(id, userId, userEmail);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.GetUserCartAsync(userId, userEmail);
            if(cart == null)
            {
                return View("NotFound");
            }
            var order = await _orderService.OrderAsync(cart);
            return View("OrderCompleted");
        }
    }
}
