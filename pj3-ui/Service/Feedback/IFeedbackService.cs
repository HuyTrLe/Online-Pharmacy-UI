using pj3_ui.Models;
using pj3_ui.Models.Feedback;

namespace pj3_ui.Service.Home
{
    public interface IFeedbackService
    {
        int InsertFeedback(FeedbackModel feedback);

        IEnumerable<FeedbackModel> GetFeedback();

        int GetFeedBackById(FeedbackModel feedback);
    }
}
