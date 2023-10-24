using pj3_ui.Models.Product;

namespace pj3_ui.Service.Specification
{
    public interface ISpecificationService
    {
        int InsertSpecification(SpecificationModel spec);
        int DeleteSpecification(SpecificationModel spec);
        SpecificationModel CheckUniqueByName(SpecificationModel spec);

        IEnumerable<SpecificationModel> GetSpecification();
        int UpdateSpecification(SpecificationModel spec);
        SpecificationModel GetSpecificationByID(int ID);
    }

}
