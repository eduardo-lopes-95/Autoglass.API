using Autoglass.API.Infra.Filter;

namespace Autoglass.Domain.Core.Services;
public interface IUriService
{
    Uri GetPageUri(PaginationFilter filter, string route);
}