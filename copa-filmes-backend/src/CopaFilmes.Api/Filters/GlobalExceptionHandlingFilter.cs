using CopaFilmes.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace CopaFilmes.Api.Filters
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlingFilter> _logger;

        public GlobalExceptionHandlingFilter(ILogger<GlobalExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(1, context.Exception, context.Exception.Message);

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
                context.Result = new JsonResult(context.Exception.StackTrace);
            }
        }
    }
}
