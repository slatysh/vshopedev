using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Vshope.Common.Exception;

namespace Vshope.Web.Helpers
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is ArgumentException
                || exception is BadRequestException
                || exception is ValidationException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
            else if (exception is BusinessLogicException)
            {
                context.Response.StatusCode = 520;
            }
            else
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            var result = JsonConvert.SerializeObject(new
            {
                message = exception.Message,
                innerException = exception.InnerException?.Message
            });
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
