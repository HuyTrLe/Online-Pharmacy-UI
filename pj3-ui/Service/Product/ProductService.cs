using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models.Feedback;
using pj3_ui.Models;
using pj3_ui.Models.Product;

namespace pj3_ui.Service.Product
{
    public class ProductService : IProductService
    {

        private AppSetting _appSetting;
        public ProductService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public int CheckUniqueByName(ProductModel product)
        {
            var callRespones = CallApi<ProductModel, HttpResultObject>.PostAsJsonAsync(product, _appSetting.UrlApi, _appSetting.ProductUrl.CheckUniqueByName);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProduct()
        {
            var callRespones = CallApi<IEnumerable<ProductModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ProductUrl.GetProduct);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductModel>>();

                return result;
                throw new NotImplementedException();
            }
            return null;
        }



        public ProductModel GetProductByID(int ID)
        {
            ProductGet productGet = new ProductGet();
            productGet.ID = ID;
            var callRespones = CallApi<ProductGet, HttpResultObject>.PostAsJsonAsync(productGet, _appSetting.UrlApi, _appSetting.ProductUrl.GetProductByID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<ProductModel>();

                return result;
            }
            return null;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            var callRespones = CallApi<IEnumerable<ProductModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ProductUrl.GetProduct);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductModel>>();
                return result;
            }
            return null;
        }

        public int InsertProductByID(ProductModel product)
        {
            throw new NotImplementedException();
        }
        public int InsertProduct(ProductModel product)
        {
            var callRespones = CallApi<ProductModel, HttpResultObject>.PostAsJsonAsync(product, _appSetting.UrlApi, _appSetting.ProductUrl.InsertProduct);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int UpdateProduct(ProductModel product)
        {
            var callRespones = CallApi<ProductModel, HttpResultObject>.PostAsJsonAsync(product, _appSetting.UrlApi, _appSetting.ProductUrl.UpdateProduct);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }
        public IEnumerable<ProductModel> GetProductByCategoryID(int categoryID)
        {
            ProductGet productGet = new ProductGet();
            productGet.CategoryID = categoryID;
            var callRespones = CallApi<ProductGet, HttpResultObject>.PostAsJsonAsync(productGet, _appSetting.UrlApi, _appSetting.ProductUrl.GetProductByCategoryID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductModel>>();

                return result;
            }
            return null;
        }



        public int InsertProductByCategoryID(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProductByID(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
