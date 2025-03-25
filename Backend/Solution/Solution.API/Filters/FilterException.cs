using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Solution.Communication.Responses;
using Solution.Exceptions;
using Solution.Exceptions.ExceptionBase;
using System;
using System.Net;

namespace Solution.API.Filters
{
    public class FilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is SolutionException)
                HandleExceptions(context);
            else 
                HandleUnknownExceptions(context);
        }

        private void HandleExceptions(ExceptionContext context)
        {
            if (context.Exception is SolutionException)
            {
                var exception = context.Exception as ErrorOnValidationException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessage));
            }     
        }

        private void HandleUnknownExceptions(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.UNKNOWN_ERROR));
        }
    }
}
