using Microsoft.AspNetCore.Mvc;
using pj3_ui.Service.Product;

namespace pj3_ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly Lazy<IProductService> _productService;
        public ProductController(IProductService productService)
        {
            _productService = new Lazy<IProductService>(() => productService);
        }

        public IActionResult IndexAdmin()
        {
            var result = _productService.Value.GetProduct();
            return View(result);
        }
         public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
