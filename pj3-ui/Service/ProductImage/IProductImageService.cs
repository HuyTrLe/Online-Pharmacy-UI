using pj3_ui.Models.Product;

namespace pj3_ui.Service.ProductImage
{
    public interface IProductImageService
    {
        IEnumerable<ProductImageModel> GetProductImage();

        int InsertProductImage(ProductImageModel ProductImage);

        int UpdateProductImage(ProductImageModel ProductImage);

        int DeleteProductImage(ProductImageModel ProductImage);

        IEnumerable<ProductImageModel> CheckProductImage(ProductImageModel ProductImage);

        IEnumerable<ProductImageModel> GetProductImageByID(ProductImageModel productImage);
        List<ProductImageModel> InsertProductImage(int productId, List<IFormFile> productImages);
    }
}
