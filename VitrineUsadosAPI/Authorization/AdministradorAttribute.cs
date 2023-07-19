namespace WebApi.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AdministradorAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        if (context.ActionDescriptor.EndpointMetadata.OfType<PublicoAttribute>().Any())
            return;

        var usuario = context.HttpContext.Items["Usuario"];

        if (usuario == null)
            context.Result = new JsonResult(
                new { message = "Não Autorizado" }
            ) {
                StatusCode = StatusCodes.Status401Unauthorized 
            };
    }
}