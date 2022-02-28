using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SalesMvc.Web.Libraries.Filters
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// Execute before controller
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Access Denied!" };
            }
            {
                Uri uri = new Uri(referer);
                string hostReferer = uri.Host;
                string hostServer = context.HttpContext.Request.Host.Host;

                if (hostReferer != hostServer)
                {
                    context.Result = new ContentResult() { Content = "Access Denied!" };
                }
            }
        }

        /// <summary>
        /// Execute after controller
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
