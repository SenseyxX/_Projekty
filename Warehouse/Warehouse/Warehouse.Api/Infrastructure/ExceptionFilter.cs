using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Warehouse.Api.Infrastructure
{
    internal sealed class ExceptionFilter : ExceptionFilterAttribute
    {
        private const string ResponseContentType = "application/json";

        public override void OnException(ExceptionContext exceptionContext)
        {
            var response = exceptionContext.HttpContext.Response;
            var message = exceptionContext.Exception.Message;
            var statusCode = FindCorrespondingStatusCode(exceptionContext.Exception);
            CreateResponse(response, message, statusCode);
        }

        private static void CreateResponse(
            HttpResponse response,
            string errorMessage,
            HttpStatusCode statusCode)
        {
            var result = JsonConvert.SerializeObject(
                new
                {
                    Message = errorMessage,
                    StatusCode = (int) statusCode,
                });

            response.StatusCode = (int) statusCode;
            response.ContentType = ResponseContentType;
            response.WriteAsync(result);
        }

        private static HttpStatusCode FindCorrespondingStatusCode(Exception exception) =>
            exception switch
            {
                NullReferenceException _ => HttpStatusCode.NotFound,
                UnauthorizedAccessException _ => HttpStatusCode.Unauthorized,
                InvalidOperationException _ => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError,
            };
    }
}
