using pj3_ui.Models.Product;

namespace pj3_ui.Service.Specification
{
    public interface IProductSpecificationService
    {
        int InsertProductSpecification(ProductSpecification productSpec);
        IEnumerable<ProductSpecification> GetProductSpecification();
        int UpdateProductSpecification(ProductSpecification productSpec);

        ProductSpecification CheckSpecName(ProductSpecification spec);

        IEnumerable<ProductSpecification> CheckSpecCount(ProductSpecification productSpec);

        int DeleteProductSpecification(ProductSpecification productSpec);

        int InsertProductSpecificationByID(ProductSpecification productSpec);
        ProductSpecification GetProductSpecificationByID(int ID);
        
    }
}
