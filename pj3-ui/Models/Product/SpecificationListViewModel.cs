using pj3_ui.Models.Product;

namespace pj3_ui.Models.Product
{
    public class SpecificationListViewModel
    {
        public List<SpecificationModel> SpecsItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
