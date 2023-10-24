using pj3_ui.Models.Product;

namespace pj3_ui.Service.Product
{
    public interface IProductService
    {
        int InsertProduct(ProductModel product);
        IEnumerable<ProductModel> GetProduct();
        int UpdateProduct(ProductModel product);

        int DeleteProduct(ProductModel product);

		int InsertProductByID(ProductModel product);
		ProductModel GetProductByID(int ID);
		int InsertProductByCategoryID(ProductModel product);
		IEnumerable<ProductModel> GetProductByCategoryID(int categoryID);
        IEnumerable<ProductModel> GetProducts();

        IEnumerable<ProductModel> GetProductByID(ProductModel product);

    }

}
