using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Timor.Cms.Infrastructure.Exceptions;
using Timor.Cms.Infrastructure.Models;

namespace Timor.Cms.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExceptionFilter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ExceptionResult();

            var exception = context.Exception;

            if (exception is BusinessException businessException)
            {
                result.ErrorMessage = businessException.ErrorMessage;
                result.ErrorDetail = exception.StackTrace;
                if (!_hostingEnvironment.IsProduction())
                {
                    result.DebugInfo = businessException.ErrorDetail ?? businessException.InnerException?.Message;
                }
            }
            else
            {
                result.ErrorMessage = exception.Message;
                result.ErrorDetail = exception.StackTrace;
                result.DebugInfo = exception.InnerException?.Message;
            }

            context.Result = new JsonResult(result);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
