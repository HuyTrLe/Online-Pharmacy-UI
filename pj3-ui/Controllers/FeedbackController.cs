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

        public IActionResult IndexAdmin(int page = 1, int pageSize = 10)
        {
            // Get a list of feedback items from your service.
            var feedbackItems = _feedbackService.Value.GetFeedback();

            // Calculate the total number of pages.
            var totalPages = (int)Math.Ceiling((double)feedbackItems.Count() / pageSize);

            // Ensure that the page parameter is within a valid range.
            page = Math.Max(1, Math.Min(totalPages, page));

            // Retrieve the feedback items for the current page.
            var pagedFeedbackItems = feedbackItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Create a view model to pass to the view.
            var viewModel = new FeedbackListViewModel
            {
                FeedbackItems = pagedFeedbackItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }


        public int InsertFeedback(FeedbackModel feedbackModel)
		{
            var result = _feedbackService.Value.InsertFeedback(feedbackModel);

			return result;
		}

		public int GetFeedBackById(FeedbackModel feedbackModel)
		{
			var result = _feedbackService.Value.GetFeedBackById(feedbackModel);
			return result;
		}
	}
}
