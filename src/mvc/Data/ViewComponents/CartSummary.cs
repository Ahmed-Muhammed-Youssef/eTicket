﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Interfaces;
using System.Security.Claims;

namespace mvc.Data.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private readonly ICartService _cartService;
        public CartSummary(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = UserClaimsPrincipal.FindFirst(ClaimTypes.Email)!.Value;

            var cart = await  _cartService
                .GetUserCartAsync(userId, userEmail);
            if(cart == null)
            {
                return View(0);
            }
            return View(cart.CartItems.Count());
        }
    }
}
