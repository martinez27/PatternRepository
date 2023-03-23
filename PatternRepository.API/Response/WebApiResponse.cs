using System.Net;

namespace PatternRepository.API.Response
{
    public class WebApiResponse<TData>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public TData Data { get; }

        public WebApiResponse(TData data, string? message = null, HttpStatusCode? statusCode = null)
        {
            StatusCode = statusCode ?? HttpStatusCode.OK;
            Message = message ?? "Proceso Ejecutado Satisfactoriamente";
            Data = data;
        }
    }
}
