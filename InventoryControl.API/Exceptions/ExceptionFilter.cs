using InventoryControl.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var result = context.Result is MedicationException;

        HandleProjectException(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
        else if (context.Exception is ConflictException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Result = new ConflictObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
    }
}