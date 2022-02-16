using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesMvc.Web.Libraries.Login;

namespace SalesMvc.Web.Libraries.Filters
{
    public class EmployerAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _authorize;
        public EmployerAuthorizationAttribute(string authorize = "C")
        {
            _authorize = authorize;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var loginEmployee = (LoginEmployee)context.HttpContext.RequestServices.GetService(typeof(LoginEmployee));
            var result = loginEmployee.GetEmplyee();

            if (result == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if (result.Type == "C" && _authorize == "G")
                    context.Result = new ForbidResult();

            }
        }
    }
}
