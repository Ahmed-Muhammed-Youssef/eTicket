using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using mvc.Data.ViewModels;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMovieService _movieService;

        public OrdersController(IOrderService orderService, IMovieService movieService)
        {
            _orderService = orderService;
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            
            var cart = await _orderService.GetUserCartAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);
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
            var cart = await _orderService.AddMovieToCartAsync(id, UserPlaceHolder.UserId, UserPlaceHolder.Email);
            if(cart == null)
            {
                return View("NotFound");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
