using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Data.Static;
using mvc.Data.ViewModels;
using mvc.Helpers.Helpers;
using mvc.Interfaces;
using mvc.Models;
using mvc.Services;
using System.Security.Claims;

namespace mvc.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly PaypalClient _paypalClient;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly string clientId;

        public OrdersController(PaypalClient paypalClient, ICartService cartService, IOrderService orderService)
        {
            _paypalClient = paypalClient;
            _cartService = cartService;
            _orderService = orderService;
            clientId = paypalClient.ClientId;
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
            return View((cartVM, clientId));
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
        public IActionResult Success()
        {
            return View("OrderCompleted");
        }
        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.GetUserCartAsync(userId, userEmail);
            if (cart == null)
            {
                cart = new Cart();
            }
            try
            {
                // set the transaction price and currency
                var price = cart.GetTotalPrice().ToString();
                var currency = "USD";

                // "reference" is the transaction key
                var reference = cart.Id.ToString();

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderId);

                // var reference = response?.purchase_units[0]?.reference_id;

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
                if (userId == null || userEmail == null)
                {
                    return View("NotFound");
                }
                var cart = await _cartService.GetUserCartAsync(userId, userEmail);
                if (cart == null)
                {
                    cart = new Cart();
                }
                await _orderService.OrderAsync(cart, orderId);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
    }
}
