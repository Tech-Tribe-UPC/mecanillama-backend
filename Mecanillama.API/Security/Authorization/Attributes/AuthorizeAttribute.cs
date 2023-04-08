﻿using Mecanillama.API.Customers.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mecanillama.API.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor
            .EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            // Then skip authorization process
            return;
        // Otherwise, perform Authorization process
        var customer = (Customer)context.HttpContext.Items["Customer"];
        if (customer == null)
            context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
    }
}