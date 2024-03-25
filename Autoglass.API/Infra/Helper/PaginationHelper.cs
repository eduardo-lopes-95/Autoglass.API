using Autoglass.API.Infra.Filter;

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
}
