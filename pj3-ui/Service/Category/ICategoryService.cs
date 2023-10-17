using pj3_ui.Models.Category;

namespace pj3_ui.Service.Category
{
    public interface ICategoryService
    {

        int InsertCategory(CategoryModel Category);

        IEnumerable<CategoryModel> GetCategory();


        int UpdateCategory(CategoryModel Category);

        int DeleteCategory(CategoryModel Category);
    }
}
