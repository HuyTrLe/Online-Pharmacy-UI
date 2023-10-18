using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models;
using pj3_ui.Models.Specification;
using pj3_ui.Models.Category;

namespace pj3_ui.Service.Specification
{
    public class SpecificationService : ISpecificationService
    {

        private AppSetting _appSetting;
        public SpecificationService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public int DeleteSpecification(SpecificationModel Specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecificationModel> GetSpecification()
        {
            var callRespones = CallApi<IEnumerable<SpecificationModel>, HttpResultObject>.PostAsJsonAsync(null, _appSetting.UrlApi, _appSetting.SpecificationUrl.GetSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<SpecificationModel>>();
                return result;
            }
            return null;
        }

        public int InsertSpecification(SpecificationModel Specification)
        {
            throw new NotImplementedException();
        }

        public int UpdateSpecification(SpecificationModel Specification)
        {
            throw new NotImplementedException();
        }
    }
}
