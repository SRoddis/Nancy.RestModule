using Nancy.RestModule.Models;

namespace Nancy.RestModule.Extensions
{
    public static class ResponseModelExtensions
    {
        public static ResponseModel CreateResponse(this object model, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ResponseModel
            {
                Model = model,
                StatusCode = statusCode
            };
        }
    }
}