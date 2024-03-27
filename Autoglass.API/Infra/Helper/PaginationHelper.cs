using Autoglass.API.Domain.Core.Interfaces.Services;
using Autoglass.API.Infra.Filter;
using Autoglass.API.Shared.Base;

namespace Autoglass.API.Infra.Helper;

public static class PaginationHelper
{
    public static IEnumerable<T> PagedData<T>(PaginationFilter filter, IEnumerable<T> entity)
    {
        var entityList = entity
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();

        return entityList;
    }

    public static BasePagedResponse<IEnumerable<T>> CreatePagedReponse<T>(IEnumerable<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
    {
        var respose = new BasePagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        respose.NextPage =
            validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
            ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
            : null;
        respose.PreviousPage =
            validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
            ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
            : null;
        respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
        respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
        respose.TotalPages = roundedTotalPages;
        respose.TotalRecords = totalRecords;
        return respose;
    }
}
