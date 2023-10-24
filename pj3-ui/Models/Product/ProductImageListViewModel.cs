namespace pj3_ui.Models.Product
{
    public class ProductImageListViewModel
    {
        public List<ProductImageModel> ProductImgItems { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
