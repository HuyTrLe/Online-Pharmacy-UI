using Microsoft.AspNetCore.Mvc;
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
        //public IActionResult ViewProducts(int categoryId)
        //{
        //    var products = _categoryService.Value.GetProductsByCategoryId(categoryId); // Sử dụng phương thức để lấy sản phẩm dựa trên categoryId
        //    return View("Shop", products); // Trả về trang Shop.cshtml với danh sách sản phẩm
        //}

    }
}
