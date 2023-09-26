using System.Net;

namespace pj3_ui.Models
{
    public class HttpResultObject
    {
        public dynamic Statuc { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public dynamic Data { get; set; }
    }
}
