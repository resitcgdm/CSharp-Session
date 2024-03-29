﻿using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SessionYapısı.Models;
using SessionYapısı.Services;

namespace SessionYapısı.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        //sepet bilgisine ulaşmamız icin sessiona ulaşmamız lazım 
        private ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService=cartSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
