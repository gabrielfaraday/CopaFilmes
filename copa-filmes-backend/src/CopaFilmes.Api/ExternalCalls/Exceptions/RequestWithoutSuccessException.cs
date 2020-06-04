using System;

namespace CopaFilmes.Api.ExternalCalls.Exceptions
{
    public class RequestWithoutSuccessException : Exception
    {
        public RequestWithoutSuccessException(string message) : base(message)
        {
        }
    }
}