using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pj3_ui.Models;
using pj3_ui.Models.Feedback;

namespace pj3_ui.Service.Home
{
    public class FeedbackService : IFeedbackService
    {
        private AppSetting _appSetting;
        public FeedbackService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public int InsertFeedback(FeedbackModel feedback)
        {
			var callRespones = CallApi<FeedbackModel, HttpResultObject>.PostAsJsonAsync(feedback, _appSetting.UrlApi, _appSetting.FeedbackUrl.InsertFeedback);
			if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
			{
				string data = JsonConvert.SerializeObject(callRespones.Item1);
				JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
			}
			return 0;
		}
    }
}
