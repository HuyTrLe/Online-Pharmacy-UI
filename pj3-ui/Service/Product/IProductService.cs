using pj3_ui.Models.Product;

namespace pj3_ui.Service.Product
{
    public interface IProductService
    {
        int InsertProduct(ProductModel product);

        int UpdateProduct(ProductModel product);

        int DeleteProduct(ProductModel product);

        IEnumerable<ProductModel> GetProducts();

        IEnumerable<ProductModel> GetProductByID(ProductModel product);

    }
}
