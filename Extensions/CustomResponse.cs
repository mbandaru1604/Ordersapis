using System.Net;

namespace OrdersAPI.Extensions
{
    public class CustomResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorDetails { get; set; }
        public object? Result { get; set; }
    }
}
