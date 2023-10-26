using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pj3_ui.Models.Product;
using pj3_ui.Service.Product;
using pj3_ui.Service.ProductImage;
using pj3_ui.Service.Specification;

namespace pj3_ui.Controllers
{
    public class ProductSpecificationController : Controller
    {
        private readonly Lazy<IProductSpecificationService> _productSpecService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ISpecificationService> _specService;
        public ProductSpecificationController(IProductSpecificationService productSpecService, IProductService productService, ISpecificationService specService)
        {
            _productSpecService = new Lazy<IProductSpecificationService>(() => productSpecService);
            _productService = new Lazy<IProductService>(() => productService);
            _specService = new Lazy<ISpecificationService>(() => specService);
        }
        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var specItems = _productSpecService.Value.GetProductSpecification();

            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)specItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedSpecItems = specItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new ProductSpecificationListViewModel
            {
                ProductSpecItems = pagedSpecItems,
                CurrentPage = page,
                TotalPages = totalPages
            };
            var product = _productService.Value.GetProducts();
            var spec = _specService.Value.GetSpecification();
            ViewBag.Product = new SelectList(product.Select(s => new SelectListItem
            {
                Text = $"Name: {s.Name} ID: {s.ID}",
                Value = s.ID.ToString()
            }), "Value", "Text");
            ViewBag.Spec = new SelectList(spec.Select(s => new SelectListItem
            {
                Text = $"Name: {s.Name} Unit: {s.Unit} (ID: {s.ID})",
                Value = s.ID.ToString()
            }), "Value" , "Text");

            return View(viewModel);
        }

        public int Update(ProductSpecification productSpec)
        {
            var result = _productSpecService.Value.UpdateProductSpecification(productSpec);
            return result;
        }

        public int Delete(ProductSpecification productSpec)
        {
            var result = _productSpecService.Value.DeleteProductSpecification(productSpec);
            return result;
        }

        public int InsertProductSpec(ProductSpecification productSpec)
        {
            var result = _productSpecService.Value.InsertProductSpecification(productSpec);
            return result;
        }

        public int CheckSpecName(ProductSpecification productSpec)
        {
            var result = _productSpecService.Value.CheckSpecName(productSpec);
            if (result != null)
            {
                return -1;
            }
            return 1;
        }

        public int CheckSpecCount(ProductSpecification productSpec)
        {
            var result = _productSpecService.Value.CheckSpecCount(productSpec);
            if (result.Count(X => X.ProductID == productSpec.ProductID) >= 10)
            {
                return -1;
            }
            return 1;
        }
    }
}
