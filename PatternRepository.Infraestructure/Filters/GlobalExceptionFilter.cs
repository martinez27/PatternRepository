using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PatternRepository.Core.Exceptions;
using System.Net;

namespace PatternRepository.Infraestructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        {
            if (context.Exception.GetType() == typeof(BusinessExceptions))
            {
                var exception = (BusinessExceptions)context.Exception;
                var validation = new
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = $"{HttpStatusCode.BadRequest}",//HttpStatusCode.BadRequest.ToString,
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] {validation}    
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
