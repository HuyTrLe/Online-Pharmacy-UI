using pj3_ui.Models.Product;

namespace pj3_ui.Service.Product
{
    public interface IProductService
    {
        int InsertProduct(ProductModel product);
        IEnumerable<ProductModel> GetProduct();


        int UpdateProduct(ProductModel product);

        int DeleteProduct(ProductModel product);
    }
}
