namespace pj3_ui.Models
{
    public class AppSetting
    {
        public ApiUrl ApiUrl { get; set; }
        public UserUrl UserUrl { get; set; }
        public string UrlApi { get; set; }

		public FeedbackUrl FeedbackUrl { get; set; }

        public CategoryUrl CategoryUrl { get; set; }
	}
	public class ApiUrl
    {
        public string GetMovies { get; set; }
    }
    public class UserUrl
    {
        public string Login { get; set; }
        public string GetUser { get; set; }
        public string UpdateUser { get; set; }
        public string InsertUser { get; set; }
    }

    public class FeedbackUrl
    {
        public string InsertFeedback { get; set; }
    }

    public class CategoryUrl
    {
        public string GetCategory { get; set; }
        public string InsertCategory { get; set; }
    }
}
