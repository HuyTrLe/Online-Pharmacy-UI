using pj3_ui.Models.Specification;

namespace pj3_ui.Service.Specification
{
    public interface ISpecificationService
    {
        int InsertSpecification(SpecificationModel specification);
        IEnumerable<SpecificationModel> GetSpecification();


        int UpdateSpecification(SpecificationModel specification);

        int DeleteSpecification(SpecificationModel specification);
    }
}
