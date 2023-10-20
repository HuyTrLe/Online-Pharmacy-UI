namespace pj3_ui.Models
{
    public class AppSetting
    {
        public ApiUrl ApiUrl { get; set; }
        public UserUrl UserUrl { get; set; }
        public CareerUrl CareerUrl { get; set; }
        public string UrlApi { get; set; }

		public FeedbackUrl FeedbackUrl { get; set; }
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
        public string CheckPassword { get; set; }
        public string ChangePassword { get; set; }
        public string UpdateFileName { get; set; }
        public string DeleteEducation { get; set; }
    }

    public class FeedbackUrl
    {
        public string InsertFeedback { get; set; }
    }
    public class CareerUrl
    {
        public string GetCareer { get; set; }
        public string GetCareerByID { get; set; }
        public string InsertCareerJob { get; set; }
        public string GetCareersByUserID { get; set; }
        public string GetCareerDetailByUserID { get; set; }
        public string CheckResume { get; set; }


    }
}
