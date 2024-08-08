using pj3_ui.Models.Product;

namespace pj3_ui.Models.Product
{
    public class ProductsListViewModel
    {
        public List<ProductModel> ProductItems { get; set; }

        public List<CategoryModel> CategoryItems {  get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
