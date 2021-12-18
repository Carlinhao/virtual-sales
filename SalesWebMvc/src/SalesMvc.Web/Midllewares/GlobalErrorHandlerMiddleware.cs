using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Net;

namespace SalesMvc.Web.Midllewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestDelegate> _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next,
                                            ILogger<RequestDelegate> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokAsync(HttpContext context)
        {
            if (context == null)
                return;
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred whilst processing your request",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
