using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace pj3_ui.Models
{
    public static class CallApi<T, R> where R : class
    {
        private static HttpClient client;

        

        public static Tuple<R, BaseApiResponse> GetAsJsonAsync(T value, string uri, string path, string token = "")
        {
            BaseApiResponse responseModel = new BaseApiResponse();
            try
            {
                var config = new HttpClientHandler();               
                R response = null;
                client = new HttpClient(config);
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromMinutes(1);

                string urlQueryString = value != null ? string.Format("{0}?{1}", path, ParseModelToQueryString(value)) : path;
                HttpResponseMessage httpResponseMessage = client.GetAsync(urlQueryString).Result;

                responseModel.Status = httpResponseMessage.StatusCode.ToString();
                responseModel.Code = (int)httpResponseMessage.StatusCode;
                responseModel.Message = httpResponseMessage.ReasonPhrase;

                httpResponseMessage.EnsureSuccessStatusCode();
                string mediaType = httpResponseMessage.Content.Headers.ContentType.MediaType;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    if (mediaType.Contains("text/html"))
                    {
                        var strResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<R>(strResult));
                        response = task.Result;
                    }
                    else if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        response = httpResponseMessage.Content.ReadAsJsonAsync<R>().Result;
                    }
                }
                return new Tuple<R, BaseApiResponse>(response, responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Code = (int)HttpStatusCode.InternalServerError;
                responseModel.Message = ex.Message;//"An Unknown Error Occured!";
                return new Tuple<R, BaseApiResponse>(null, responseModel);
            }
        }
        private static string ParseModelToQueryString(T data)
        {
            string result = "";
            var type = data.GetType();
            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(data, null);
                if (value != null)
                    result += string.Format("{0}={1}&", item.Name, item.PropertyType == typeof(string) ? HttpUtility.UrlEncode(value.ToString()) : value.ToString());
            }
            if (result.EndsWith("&"))
                result = result.Substring(0, result.Length - 1);
            return result;
        }

        public static Tuple<R, BaseApiResponse> PostAsJsonAsync(T value, string uri, string path, string token = "")
        {
            BaseApiResponse responseModel = new BaseApiResponse();
            try
            {
                var config = new HttpClientHandler();
               
                R response = null;
                client = new HttpClient(config);
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromMinutes(1);
                
                string json = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = client.PostAsync(
                    $"" + path + "", httpContent).Result;

                responseModel.Code = (int)httpResponseMessage.StatusCode;
                responseModel.Message = httpResponseMessage.ReasonPhrase;

                httpResponseMessage.EnsureSuccessStatusCode();
                string mediaType = httpResponseMessage.Content.Headers.ContentType.MediaType;
                if (mediaType.Contains("text/html"))
                {
                    var strResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<R>(strResult));
                    response = task.Result;
                }
                else if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = httpResponseMessage.Content.ReadAsJsonAsync<R>().Result;
                }
                return new Tuple<R, BaseApiResponse>(response, responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Code = (int)((System.Net.Http.HttpRequestException)ex).StatusCode;// (int)HttpStatusCode.InternalServerError;
                responseModel.Message = ex.Message;//"An Unknown Error Occured!";
                return new Tuple<R, BaseApiResponse>(null, responseModel);
            }
        }


    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static async Task<T> ReadAsStreamAsync<T>(this HttpContent content)
        {
            Stream stream = await content.ReadAsStreamAsync();

            if (stream.Length is 0)
            {
                return default;
            }

            return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static async Task<T> ReadRawContentAsync<T>(this HttpContent content)
        {
            Task<string> strResult = content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(await strResult);
            }
            catch (Exception e)
            {
                throw new JsonReaderException(e.Message, e);
            }
        }
    }
}
