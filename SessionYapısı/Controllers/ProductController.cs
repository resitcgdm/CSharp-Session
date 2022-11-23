using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SessionYapısı.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Ekle()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Ekle(Product product)
        {
            _productService.Ekle(product);
            return RedirectToAction("Listele");
            
        }
        public IActionResult Sil()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Sil(Product product)
        {
            _productService.Sil(product);
           return RedirectToAction("Listele");

        }
        public IActionResult Guncelle()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Guncelle(Product product)
        {
            _productService.Guncelle(product);
            return RedirectToAction("Listele");

        }
        [HttpGet]
        public IActionResult Listele()
        {
            var result = _productService.UrunListele();
            return View(result);

        }
        [HttpGet]
        public IActionResult IdIleSil(Product product)
        {
           var urun= _productService.IdBul(product);
            _productService.Sil(urun);
            return RedirectToAction("Listele");
        }
    
    }
}
