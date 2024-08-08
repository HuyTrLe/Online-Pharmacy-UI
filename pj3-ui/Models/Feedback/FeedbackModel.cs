namespace pj3_ui.Models.Feedback
{
	public class FeedbackModel
	{
		public int ID { get; set; }
		public string FullName { get; set; }
		public string CompanyName { get; set; }

		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public string Subject { get; set; }

		public string Comment { get; set; }

		public DateTime CreateDate { get; set; }
	}
}
