using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Timor.Cms.Infrastructure.Models;

namespace Timor.Cms.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<ValidationError>();

                foreach (var error in context.ModelState)
                {
                    var field = error.Key;
                    var message = error.Value.Errors.FirstOrDefault()?.ErrorMessage;

                    errors.Add(new ValidationError(field, message));
                }

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new JsonResult(new ValidationResult(errors));
            }
            else
            {
                await next();    
            }
        }
    }
}