using Microsoft.AspNetCore.Mvc;
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

        public IActionResult IndexAdmin()
        {
            var result = _categoryService.Value.GetCategory();
            return View(result);
        }
        public IActionResult UpdateAdmin(CategoryModel category)
        {
            var result = _categoryService.Value.UpdateCategory(category);

            return View(result);
        }


    }
}
