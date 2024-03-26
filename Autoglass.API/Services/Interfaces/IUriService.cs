using Autoglass.API.Infra.Filter;

namespace Autoglass.API.Services.Interfaces;
public interface IUriService
{
    Uri GetPageUri(PaginationFilter filter, string route);
}