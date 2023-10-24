namespace pj3_ui.Models.Product
{
    public class ProductSpecificationListViewModel
    {
        public List<ProductSpecification> ProductSpecItems { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
