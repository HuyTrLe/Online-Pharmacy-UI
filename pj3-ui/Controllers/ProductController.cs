using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.Product;
using pj3_ui.Service.Category;
using pj3_ui.Service.Home;
using pj3_ui.Service.Product;
using pj3_ui.Service.ProductImage;
using Microsoft.AspNetCore.Http;
using pj3_ui.Service.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using pj3_ui.Service.Specification;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace pj3_ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ISpecificationService> _specService;
        private readonly Lazy<IProductSpecificationService> _productSpecificationService;
        public ProductController(IProductService productService, IProductImageService productImageService, ICategoryService categoryService, ISpecificationService specService, IProductSpecificationService productSpecService)
        {
            _productService = new Lazy<IProductService>(() => productService);
            _productImageService = new Lazy<IProductImageService>(() => productImageService);
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
            _specService = new Lazy<ISpecificationService>(() => specService);
            _productSpecificationService = new Lazy<IProductSpecificationService>(() => productSpecService);
        }
        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var productItems = _productService.Value.GetProduct();
            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)productItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedProductItems = productItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new ProductsListViewModel
            {
                ProductItems = pagedProductItems,
                CurrentPage = page,
                TotalPages = totalPages
            };
            var categories = _categoryService.Value.GetCategory();
            ViewBag.Categories = new SelectList(categories.Select(s => new SelectListItem
            {
                Text = $"{s.Name} (ID: {s.ID})",
                Value = s.ID.ToString()
            }), "Value", "Text");


            return View(viewModel);
        }
        public IActionResult Create()
        {
            var categories = _categoryService.Value.GetCategory();
            var specs = _specService.Value.GetSpecification();
            ViewBag.Categories = new SelectList(categories, "ID", "Name");
            ViewBag.Specs = new SelectList(specs.Select(s => new SelectListItem
            {
                Text = $"{s.Name} ({s.Unit})",
                Value = s.ID.ToString()
            }), "Value", "Text");


            var productModel = new ProductModel();

            return View(productModel);
        }
        public IActionResult InsertProduct(ProductModel productModel, List<IFormFile> productImages, List<ProductSpecification> ProductSpecifications)
        {
            try
            {
                // Insert the product first to get its ID
                var productId = _productService.Value.InsertProduct(productModel);

                if (productId > 0)
                {
                    // Insert product specifications
                    if (ProductSpecifications != null && ProductSpecifications.Count > 0)
                    {
                        List<ProductSpecification> productSpec = new List<ProductSpecification>();

                        foreach (var productSpecification in ProductSpecifications)
                        {
                            productSpecification.ProductID = productId; // Set the ProductID
                                                                        // Insert the product specification
                            _productSpecificationService.Value.InsertProductSpecification(productSpecification);
                        }
                    }


                    if (productImages != null && productImages.Count > 0)
                    {
                        List<ProductImageModel> images = new List<ProductImageModel>();

                        foreach (var imageFile in productImages)
                        {
                            if (imageFile.Length > 0)
                            {
                                // Generate a unique filename for each image
                                var uniqueFilename = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                                var filePath = Path.Combine("wwwroot/admin/img/products", uniqueFilename);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    imageFile.CopyTo(stream);
                                }

                                // Create a ProductImageModel and set its properties
                                ProductImageModel image = new ProductImageModel
                                {
                                    Image = "/admin/img/products/" + uniqueFilename,
                                    ProductID = productId // Set the product ID for the image
                                };

                                // Add the image to the list
                                images.Add(image);
                            }
                        }

                        // Insert the product images
                        foreach (var image in images)
                        {
                            _productImageService.Value.InsertProductImage(image);
                        }
                    }
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return Json(new { success = false, message = "Failed to add product !!!" });
            }
        }


        public IActionResult ProductList()
        {
            var result = _productService.Value.GetProduct();
            var categoryList = _categoryService.Value.GetCategory();

            ViewBag.category = categoryList;

			return View(result);
        }
        

        public IActionResult ProductDetails(int ID)
        {
			var product = _productService.Value.GetProductByID(ID);

			if (product == null)
			{
				// Xử lý trường hợp sản phẩm không tồn tại
				return View("ProductNotFound");
			}

			return View(product);
		}
        public IActionResult AdminProductList()
        {
            var result = _productService.Value.GetProduct();
            return View(result);
        }
        public int UpdateProduct(ProductModel product)
        {
            var result = _productService.Value.UpdateProduct(product);
            return result;
        }

        public IEnumerable<ProductModel> ProductCategory(int categoryID)
		{
            var product = _productService.Value.GetProductByCategoryID(categoryID);
			return product;
		}


    }
}
 