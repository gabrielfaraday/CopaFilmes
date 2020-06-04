using CopaFilmes.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace CopaFilmes.Api.Filters
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.Out.WriteLine($"ERROR: {context.Exception.Message} - {context.Exception.StackTrace}");

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            if (context.Exception is QuantidadeFilmesInvalida)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(context.Exception.Message);
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult($"ERROR: {context.Exception.Message} - {context.Exception.StackTrace}");
            }
        }
    }
}
