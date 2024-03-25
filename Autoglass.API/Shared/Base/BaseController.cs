using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Autoglass.API.Shared.Base;

public abstract class BaseController : ControllerBase
{
    protected new IActionResult Response(BaseResponse response, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        if (!response.Success)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)statusCode, response);
            }
            return BadRequest(response);
        }

        if (statusCode != HttpStatusCode.OK)
        {
            return StatusCode((int)statusCode, response);
        }

        return response.GetType() != typeof(BaseResponse<object>) || ((BaseResponse<object>)response)?.Data != null ?
            Ok(response) : StatusCode((int)HttpStatusCode.NoContent, response);
    }
}
