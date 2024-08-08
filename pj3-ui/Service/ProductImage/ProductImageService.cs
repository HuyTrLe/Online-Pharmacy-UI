using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models;
using pj3_ui.Models.Product;

namespace pj3_ui.Service.ProductImage
{
    public class ProductImageService : IProductImageService
    {
        private AppSetting _appSetting;
        public ProductImageService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public IEnumerable<ProductImageModel> CheckProductImage(ProductImageModel ProductImage)
        {
            var callRespones = CallApi<ProductImageModel, HttpResultObject>.PostAsJsonAsync(ProductImage, _appSetting.UrlApi, _appSetting.ProductImageUrl.CheckProductImage);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductImageModel>>();
                return result;
            }
            return null;
        }

        public int DeleteProductImage(ProductImageModel ProductImage)
        {
            var callRespones = CallApi<ProductImageModel, HttpResultObject>.PostAsJsonAsync(ProductImage, _appSetting.UrlApi, _appSetting.ProductImageUrl.DeleteProductImage);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public IEnumerable<ProductImageModel> GetProductImage()
        {
            var callRespones = CallApi<IEnumerable<ProductImageModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ProductImageUrl.GetProductImage);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductImageModel>>();
                return result;
            }
            return null;
        }

        public IEnumerable<ProductImageModel> GetProductImageByID(ProductImageModel productImage)
        {
            var callRespones = CallApi<IEnumerable<ProductImageModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ProductImageUrl.GetProductImage);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<ProductImageModel>>();
                return result;
            }
            return null;
        }

        public int InsertProductImage(ProductImageModel ProductImage)
        {
            var callRespones = CallApi<ProductImageModel, HttpResultObject>.PostAsJsonAsync(ProductImage, _appSetting.UrlApi, _appSetting.ProductImageUrl.InsertProductImage);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public List<ProductImageModel> InsertProductImage(int productId, List<IFormFile> productImages)
        {
            List<ProductImageModel> productImageModels = new List<ProductImageModel>();

            foreach (var image in productImages)
            {
                // Generate a unique filename for the image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;

                // Get the path where the image will be saved
                string filePath = Path.Combine(@"wwwroot\assets\images\Products", uniqueFileName);

                // Save the image to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                // Create a ProductImageModel for this image
                var productImageModel = new ProductImageModel
                {
                    ProductID = productId,
                    Image = uniqueFileName
                };

                // Add the productImageModel to the list
                productImageModels.Add(productImageModel);
            }

            foreach (var productImage in productImageModels)
            {
                int result = InsertProductImage(productImage);
            }

            return productImageModels;
        }

        public int UpdateProductImage(ProductImageModel ProductImage)
        {
            var callRespones = CallApi<ProductImageModel, HttpResultObject>.PostAsJsonAsync(ProductImage, _appSetting.UrlApi, _appSetting.ProductImageUrl.UpdateProductImage);
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
