using Nancy.Responses.Negotiation;

namespace Nancy.RestModule.Models
{
    public class ResponseModel : ResponseModel<object>
    {
    }

    public class ResponseModel<TModel>
    {
        public MediaRange AllowedMediaRange { get; set; }

        public string AllowedContentType { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public TModel Model { get; set; }
    }
}