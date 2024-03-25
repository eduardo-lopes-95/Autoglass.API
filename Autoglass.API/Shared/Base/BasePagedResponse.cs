using Autoglass.API.Shared.Base;

namespace Oceanica.GupyProd.Shared.Base;

public class BasePagedResponse<T> : BaseResponse<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri FirstPage { get; set; }
    public Uri LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public Uri NextPage { get; set; }
    public Uri PreviousPage { get; set; }
    
    public BasePagedResponse(T data, int pageNumber, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
