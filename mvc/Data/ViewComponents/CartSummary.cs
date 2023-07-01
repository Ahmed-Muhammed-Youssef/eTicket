using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Data.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private readonly ICartService _cartService;
        public CartSummary(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await  _cartService
                .GetUserCartAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);
            if(cart == null)
            {
                return View(0);
            }
            return View(cart.CartItems.Count());
        }
    }
}
