using pj3_ui.Models.Product;

namespace pj3_ui.Service.Category
{
    public interface ICategoryService
    {
        int InsertCategory(CategoryModel category);

        IEnumerable<CategoryModel> GetCategory();

        CategoryModel GetCategoryById(CategoryGet category);
    }
}
