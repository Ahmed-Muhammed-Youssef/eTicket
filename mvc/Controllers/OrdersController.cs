using Microsoft.AspNetCore.Mvc;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMovieService _movieService;

        public OrdersController(ICartService cartService, IMovieService movieService)
        {
            _cartService = cartService;
            _movieService = movieService;
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
    }
}
