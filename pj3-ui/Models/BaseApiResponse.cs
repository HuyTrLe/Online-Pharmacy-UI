using System.Net;

namespace pj3_ui.Models
{
    public class BaseApiResponse
    {
        public int Code { get; set; } = (int)HttpStatusCode.BadRequest;
        public string Status { get; set; } = "NotOk";
        public string Message { get; set; } = HttpStatusCode.BadRequest.ToString();
    }
}
