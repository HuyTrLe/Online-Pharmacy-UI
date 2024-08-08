using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pj3_ui.Models.Product;
using pj3_ui.Models.User;
using pj3_ui.Service.Category;

namespace pj3_ui.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Lazy<ICategoryService> _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
        }

        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var categoryItems = _categoryService.Value.GetCategory();

            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)categoryItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedCategoryItems = categoryItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new ProductsListViewModel
            {
                CategoryItems = pagedCategoryItems,
                CurrentPage = page,
                TotalPages = totalPages
            };
            return View(viewModel);
        }
        public int UpdateCategory(CategoryModel category)
        {
            var result = _categoryService.Value.UpdateCategory(category);

            return result;
        }
       
        public IActionResult InsertCategory(CategoryModel category)
        {
            var result = _categoryService.Value.InsertCategory(category);
            return View(result);
        }

    }
}
