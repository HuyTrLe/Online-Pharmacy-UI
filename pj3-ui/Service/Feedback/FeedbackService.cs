using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pj3_ui.Models;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Home
{
    public class FeedbackService : IFeedbackService
    {
        private AppSetting _appSetting;
        public FeedbackService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public IEnumerable<FeedbackModel> GetFeedback()
        {
            var callRespones = CallApi<IEnumerable<FeedbackModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.FeedbackUrl.GetFeedback);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<FeedbackModel>>();
                return result;
            }
            return null;
        }

        public int GetFeedBackById(FeedbackModel feedback)
		{
			var callRespones = CallApi<FeedbackModel, HttpResultObject>.PostAsJsonAsync(feedback, _appSetting.UrlApi, _appSetting.FeedbackUrl.GetFeedBackById);
			if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
			{
				string data = JsonConvert.SerializeObject(callRespones.Item1);
				JObject jObject = JObject.Parse(data);
				return Convert.ToInt32(jObject["Data"]);
			}
			return 0;
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
