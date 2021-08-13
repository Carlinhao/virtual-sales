using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesMvc.Web.Libraries.Login;

namespace SalesMvc.Web.Libraries.Filters
{
    /*
     * Tipos de Filtro:
     * - Authorization
     * - Resource
     * - Action
     * - Execution
     * - Result
     */

    public class CostumerAutorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var loginCostumer = (LoginCostumer)context.HttpContext.RequestServices.GetService(typeof(LoginCostumer));
            var result = loginCostumer.GetCustomer();

            if (result == null)
            {
                context.Result = new ContentResult() { Content = "Access Denied" };
            }
        }
    }
}
