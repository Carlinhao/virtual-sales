using System;
using Microsoft.AspNetCore.Mvc.Filters;

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

    public class CostumerAutorizationAtributte : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
