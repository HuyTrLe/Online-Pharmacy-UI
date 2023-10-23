using pj3_ui.Models.Product;

namespace pj3_ui.Service.Specification
{
    public interface IProductSpecificationService
    {
        int InsertProductSpecification(ProductSpecification productSpec);
        IEnumerable<ProductSpecification> GetProductSpecification();
        int UpdateProductSpecification(ProductSpecification productSpec);
        ProductSpecification GetProductSpecificationByID(int ID);
    }
}
