using Autoglass.API.Shared.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.API.Infra.Filter;

public class ValidateModelStateFilter : ActionFilterAttribute
{

    /// <inheritdoc />
    public override void OnActionExecuting(ActionExecutingContext context)
    {

        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                                                  .SelectMany(v => v.Errors)
                                                  .Select(v => new { Message = v.ErrorMessage })
                                                  .ToList();

            var response = new BaseResponse();
            errors.ForEach(error => {
                response.Errors.Add(new BaseResponseError
                {
                    ErrorCode = "INVALID_MODEL",
                    Message = error.Message,
                });
            });

            context.Result = new JsonResult(response)
            {
                StatusCode = 400
            };
        }
    }

}
