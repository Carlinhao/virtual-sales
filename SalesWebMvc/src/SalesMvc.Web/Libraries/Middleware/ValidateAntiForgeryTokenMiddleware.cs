using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace SalesMvc.Web.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAntiforgery _antiforgery;

        public ValidateAntiForgeryTokenMiddleware(
            RequestDelegate next,
            IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            var ajaxRequest = context.Request.Headers["x-requested-with"];
            var ajax = ajaxRequest == "XMLHttpRequest";

            if (HttpMethods.IsPost(context.Request.Method) && !(context.Request.Form.Files.Count == 1 && ajax))
			    await _antiforgery.ValidateRequestAsync(context);

			await _next(context);
        }
    }
}
