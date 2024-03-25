namespace Autoglass.API.Shared.Base;

public class BaseResponse
{
    public bool Success => !Errors.Any();

    public List<BaseResponseError> Errors { get; set; } = new List<BaseResponseError>();

    public static BaseResponse ThrowError(string errorCode, string message) => new()
    {
        Errors = new List<BaseResponseError>()
        {
            new BaseResponseError
            {
                ErrorCode = errorCode,
                Message = message
            }
        }
    };
}

public class BaseResponse<T> : BaseResponse
{
    public T Data { get; set; }

    public BaseResponse()
    {
    }

    public BaseResponse(T data)
    {
        Data = data;
    }

    public static new BaseResponse<T> ThrowError(string errorCode, string message) => new()
    {
        Errors = new List<BaseResponseError>()
        {
            new BaseResponseError
            {
                ErrorCode = errorCode,
                Message = message
            }
        }
    };
}
