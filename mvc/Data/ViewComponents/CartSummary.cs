using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using mvc.Models;

namespace mvc.Data.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private readonly IOrderService _orderService;
        public CartSummary(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await  _orderService
                .GetUserCartAsync(UserPlaceHolder.UserId, UserPlaceHolder.Email);
            if(cart == null)
            {
                return View(0);
            }
            return View(cart.CartItems.Count());
        }
    }
}
