namespace pj3_ui.Models.Feedback
{
    public class FeedbackListViewModel
    {
        public List<FeedbackModel> FeedbackItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}