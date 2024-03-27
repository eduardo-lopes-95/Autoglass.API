using Autoglass.API.Infra.Filter;

namespace Autoglass.API.Domain.Core.Interfaces.Services;
public interface IUriService
{
    Uri GetPageUri(PaginationFilter filter, string route);
}