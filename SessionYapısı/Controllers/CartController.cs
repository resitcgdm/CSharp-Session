using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SessionYapısı.Models;
using SessionYapısı.Services;
using System;

namespace SessionYapısı.Controllers
{
    public class CartController : Controller
    {
       private ICartSessionService _cartSessionService;
       private ICartService _cartService;
       private IProductService _productService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }
        public IActionResult SepeteEkle(int productId)
        {
            //HttpContext.Session.SetString("city", "Ankara");  Bunları burda yazarsak test edilebilirlik   olmaz.                                                             

            //HttpContext.Session.GetString("city");
            //HttpContext.Session.GetInt32("age");

            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart,productToBeAdded); //cart nesnesine ürün eklemek istiyorum.
            _cartSessionService.SetCart(cart);//Ekledikten sonra da yine sessiona atmamız gerekiyor.
            TempData.Add("message",string.Format("{0} was succesfully added to the cart!",productToBeAdded.ProductName)); //tempdata tek bir requestlik veri taşır genelde mesaj verme de kullanılır
            return RedirectToAction("Listele", "Product");





        }
        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);
        }
        public IActionResult SepettenSil(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Your product was succesfully removed from cart!"));
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult AlisverisTamamla()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public IActionResult AlisverisTamamla(ShippingDetails shippingDetails)
        {
            if(!ModelState.IsValid) //adını girmiş mi,email girmiş mi vs
            {
                return View();
            }
            else
            {
                TempData.Add("message", String.Format("Teşekkürler {0},siparişiniz hazırlanıyor", shippingDetails.FirstName));
                return View();
            }

        }
     

        public IActionResult Index()
        {
            return View();
        }
    }
}
