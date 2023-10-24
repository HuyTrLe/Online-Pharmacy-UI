using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.Product;
using pj3_ui.Service.Category;
using pj3_ui.Service.Product;
using pj3_ui.Service.ProductImage;
using pj3_ui.Service.Specification;

namespace pj3_ui.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IProductService> _productService;
        public ProductImageController(IProductImageService productImageService, IProductService productService)
        {
            _productImageService = new Lazy<IProductImageService>(() => productImageService);
            _productService = new Lazy<IProductService>(() => productService);
        }
        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var imageItems = _productImageService.Value.GetProductImage();

            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)imageItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedImageItems = imageItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new ProductImageListViewModel
            {
                ProductImgItems = pagedImageItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            var product = _productService.Value.GetProducts();
            ViewBag.Product = new SelectList(product.Select(s => new SelectListItem
            {
                Text = $"Name: {s.Name}",
                Value = s.ID.ToString()
            }), "Value", "Text");

            return View(viewModel);
        }

        public int Update(ProductImageModel productImage)
        {
            var result = _productImageService.Value.InsertProductImage(productImage);
            return result;
        }
    }
}
