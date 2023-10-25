namespace pj3_ui.Models
{
    public class AppSetting
    {
        public ApiUrl ApiUrl { get; set; }
        public UserUrl UserUrl { get; set; }
        public CareerUrl CareerUrl { get; set; }
        public string UrlApi { get; set; }

        public FeedbackUrl FeedbackUrl { get; set; }

        public ProductUrl ProductUrl { get; set; }

        public ProductImageUrl ProductImageUrl { get; set; }

        public CategoryUrl CategoryUrl { get; set; }

        public SpecUrl SpecUrl { get; set; }

        public ProductSpecUrl ProductSpecUrl { get; set; }
    }
    public class ApiUrl
    {
        public string GetMovies { get; set; }
    }
    public class UserUrl
    {
        public string Login { get; set; }
        public string GetUser { get; set; }
        public string GetAllUser { get; set; }
        public string UpdateUser { get; set; }
        public string InsertUser { get; set; }
        public string CheckPassword { get; set; }
        public string ChangePassword { get; set; }
        public string UpdateFileName { get; set; }
        public string DeleteEducation { get; set; }
        public string UpdateRole { get; set; }
    }

    public class FeedbackUrl
    {
        public string InsertFeedback { get; set; }

        public string GetFeedback { get; set; }

        public string GetFeedBackById { get; set; }

    }

    public class ProductUrl
    {
        public string InsertProduct { get; set; }
        public string GetProductByID { get; set; }

		public string GetProductByCategoryID { get; set; }

		public string UpdateProduct { get; set; }

        public string GetProduct { get; set; }

        public string DeleteProduct { get; set; }

        public string CheckUniqueByName { get; set; }
    }

    public class ProductImageUrl
    {
        public string GetProductImage { get; set; }

        public string InsertProductImage { get; set; }

        public string UpdateProductImage { get; set; }

        public string DeleteProductImage { get; set; }

        public string GetProductImageByID { get; set; }

        public string CheckProductImage { get; set; }
    }

    public class CategoryUrl
    {
        public string GetCategory { get; set; }
        public string UpdateCategory { get; set; }
        public string InsertCategory { get; set; }

        public string GetCategoryById { get; set; }
    }

    public class SpecUrl
    {
        public string GetSpecification { get; set; }
        public string InsertSpecification { get; set; }

        public string UpdateSpecification { get; set; }

        public string GetSpecificationByID { get; set; }

        public string DeleteSpecification { get; set; }

        public string CheckUniqueByName { get; set; }
    }

    public class ProductSpecUrl
    {
        public string GetProductSpecification { get; set; }
        public string InsertProductSpecification { get; set; }

        public string UpdateProductSpecification { get; set; }

        public string GetProductSpecificationByID { get; set; }

        public string DeleteProductSpecification { get; set; }

        public string CheckSpecName { get; set; }

        public string CheckSpecCount { get; set; }
    }
    public class CareerUrl
    {
        public string GetCareer { get; set; }
        public string GetAllCareer { get; set; }
        public string GetCareerByID { get; set; }
        public string InsertCareerJob { get; set; }
        public string GetCareersByUserID { get; set; }
        public string GetCareerDetailByUserID { get; set; }
        public string CheckResume { get; set; }
        public string InsertCareer { get; set; }
        public string UpdateCareer { get; set; }
        public string UpdateCareerJob { get; set; }
        public string GetCareerJob { get; set; }
        public string GetCareerJobAdmin { get; set; }
        public string UpdateStatusCareerJob { get; set; }
    }
}
