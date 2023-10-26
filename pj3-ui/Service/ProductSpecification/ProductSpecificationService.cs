using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models;
using pj3_ui.Models.Feedback;
using pj3_ui.Models.Product;
using pj3_ui.Service.Specification;

namespace pj3_ui.Service.Specification
{
    public class ProductSpecificationService : IProductSpecificationService
    {
        private AppSetting _appSetting;
        public ProductSpecificationService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public IEnumerable<ProductSpecification> CheckSpecCount(ProductSpecification productSpec)
        {
            var callRespones = CallApi<ProductSpecification, HttpResultObject>.PostAsJsonAsync(productSpec, _appSetting.UrlApi, _appSetting.ProductSpecUrl.CheckSpecCount);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductSpecification>>();
                return result;
            }
            return null;
        }

        public ProductSpecification CheckSpecName(ProductSpecification productSpec)
        {
            var callRespones = CallApi<ProductSpecification, HttpResultObject>.PostAsJsonAsync(productSpec, _appSetting.UrlApi, _appSetting.ProductSpecUrl.CheckSpecName);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<ProductSpecification>();
                return result;
            }
            return null;
        }

        public int DeleteProductSpecification(ProductSpecification productSpec)
        {
            var callRespones = CallApi<ProductSpecification, HttpResultObject>.PostAsJsonAsync(productSpec, _appSetting.UrlApi, _appSetting.ProductSpecUrl.DeleteProductSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public IEnumerable<ProductSpecification> GetProductSpecification()
        {
            var callRespones = CallApi<IEnumerable<ProductSpecification>, HttpResultObject>.PostAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ProductSpecUrl.GetProductSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductSpecification>>();
                return result;
            }
            return null;
        }

        public ProductSpecification GetProductSpecificationByID(int ID)
        {
            ProductSpecGet productSpecGet = new ProductSpecGet();
            productSpecGet.ID = ID;
            var callRespones = CallApi<ProductSpecGet, HttpResultObject>.PostAsJsonAsync(productSpecGet, _appSetting.UrlApi, _appSetting.ProductSpecUrl.GetProductSpecificationByID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<ProductSpecification>();

                return result;
            }
            return null;
        }

        public int InsertProductSpecification(ProductSpecification productSpec)
        {
            var callRespones = CallApi<ProductSpecification, HttpResultObject>.PostAsJsonAsync(productSpec, _appSetting.UrlApi, _appSetting.ProductSpecUrl.InsertProductSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int InsertProductSpecificationByID(ProductSpecification productSpec)
        {
            throw new NotImplementedException();
        }

        public int UpdateProductSpecification(ProductSpecification productSpec)
        {
            var callRespones = CallApi<ProductSpecification, HttpResultObject>.PostAsJsonAsync(productSpec, _appSetting.UrlApi, _appSetting.ProductSpecUrl.UpdateProductSpecification);
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
