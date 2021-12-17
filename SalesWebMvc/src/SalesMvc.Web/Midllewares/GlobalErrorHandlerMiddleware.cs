using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

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
                response.ContentType = "application/json";


            }
        }
    }
}
