using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.Product;

namespace pj3_ui.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private AppSetting _appSetting;
        public CategoryService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public IEnumerable<CategoryModel> GetCategory()
        {
            var callRespones = CallApi<IEnumerable<CategoryModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.CategoryUrl.GetCategory);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<CategoryModel>>();
                return result;
            }
            return null;
        }

        public CategoryModel GetCategoryById(CategoryGet categoryGet)
        {
            var callRespones = CallApi<CategoryGet, HttpResultObject>.PostAsJsonAsync(categoryGet, _appSetting.UrlApi, _appSetting.CategoryUrl.GetCategoryById);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<CategoryModel>();
                return result;
            }
            return null;

        }

        public int InsertCategory(CategoryModel category)
        {
            throw new NotImplementedException();
        }
    }
}
