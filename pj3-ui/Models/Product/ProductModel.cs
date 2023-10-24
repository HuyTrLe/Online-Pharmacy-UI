namespace pj3_ui.Models.Product
{
    public class ProductModel
    {
        public int ID { get; set; }

        public int? CategoryID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        public List<IFormFile> ProductImages { get; set; }

        public List<ProductSpecification> ProducSpecs { get; set; }
    }

    public class ProductImageModel
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string Image { get; set; } 
    }

    public class ProductSpecification
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        public int SpecID { get; set; }

        public string SpecName { get; set; }

        public string SpecValue { get; set; }

        public string SpecUnit { get; set; }
    }

    public class CategoryGet
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }
    }

    public class ProductGet
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }
    }
}
