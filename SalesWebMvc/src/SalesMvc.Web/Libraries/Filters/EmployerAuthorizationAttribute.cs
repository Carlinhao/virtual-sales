using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesMvc.Web.Libraries.Login;

namespace SalesMvc.Web.Libraries.Filters
{
    public class EmployerAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var loginEmployee = (LoginEmployee)context.HttpContext.RequestServices.GetService(typeof(LoginEmployee));
            var result = loginEmployee.GetEmplyee();

            if (result == null)
            {
                context.Result = new ContentResult() { Content = "Access Denied" };
            }
        }
    }
}
