using Autofac;
using Autoglass.Domain.Core.Repositories;
using Autoglass.Domain.Core.Services;
using Autoglass.Domain.Services;
using Autoglass.Infrastruture.Repository.Repositories;


namespace Autoglass.Infrastruture.CrossCutting.IOC;
public class ConfigurationIOC
{
    public static void Load(ContainerBuilder builder)
    {
        #region IOC Services
        builder.RegisterType<ProductService>().As<IProductService>();
        #endregion

        #region IOC Repositorys SQL
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        #endregion

    }
}
