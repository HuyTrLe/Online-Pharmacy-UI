namespace pj3_ui.Models.Product
{
    public class ProductModel
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Boolean Deleted { get; set; }
    }
}
