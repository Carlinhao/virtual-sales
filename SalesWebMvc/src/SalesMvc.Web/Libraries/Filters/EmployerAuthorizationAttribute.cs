using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Models.Constats;

namespace SalesMvc.Web.Libraries.Filters
{
    public class EmployerAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _authorize;
        public EmployerAuthorizationAttribute(string authorize = TypeEmployeeConstant.Common)
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
                if (result.Type == TypeEmployeeConstant.Common && _authorize == TypeEmployeeConstant.Manager)
                    context.Result = new ForbidResult();

            }
        }
    }
}
