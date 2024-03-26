using Autoglass.API.Infra.Filter;
using Autoglass.API.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace Autoglass.API.Services;

public class UriService : IUriService
{
    private string BaseUri;
    public UriService(string baseUri)
    {
        BaseUri = baseUri;
    }
    public Uri GetPageUri(PaginationFilter filter, string route)
    {
        var _enpointUri = new Uri(string.Concat(BaseUri, route));
        var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
        modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
        return new Uri(modifiedUri);
    }
}
