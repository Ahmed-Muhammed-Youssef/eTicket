using Microsoft.AspNetCore.Mvc;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
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
            var orders = await _orderService.
                GetUserOrdersAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);

            return View(orders == null? new List<Order>(): orders);
        }
        public async Task<IActionResult> Index()
        {
            
            var cart = await _cartService.GetUserCartAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);
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
            var cart = await _cartService.AddMovieToCartAsync(id, UserPlaceHolder.UserId, UserPlaceHolder.Email);
            if(cart == null)
            {
                return View("NotFound");
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var cart = await _cartService.RemoveMovieFromCartAsync(id, UserPlaceHolder.UserId, UserPlaceHolder.Email);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var cart = await _cartService.GetUserCartAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);
            if(cart == null)
            {
                return View("NotFound");
            }
            var order = await _orderService.OrderAsync(cart);
            return View("OrderCompleted");
        }
    }
}
