using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models.Feedback;
using pj3_ui.Service.Home;

namespace pj3_ui.Controllers
{
	public class FeedbackController : Controller
	{
		private readonly Lazy<IFeedbackService> _feedbackService;
		public FeedbackController(IFeedbackService feedbackService)
		{
			_feedbackService = new Lazy<IFeedbackService>(() => feedbackService);
		}

		public IActionResult Index()
		{
			return View();
		}

		public int InsertFeedback(FeedbackModel feedbackModel)
		{
            var result = _feedbackService.Value.InsertFeedback(feedbackModel);

			return result;
		}
	}
}
