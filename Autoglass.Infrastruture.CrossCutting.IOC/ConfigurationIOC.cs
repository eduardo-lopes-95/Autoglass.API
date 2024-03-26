using Autofac;
using Autoglass.API.Infra.Repositories;


namespace Autoglass.Infrastruture.CrossCutting.IOC;
public class ConfigurationIOC
{
    public static void Load(ContainerBuilder builder)
    {
        #region Registra IOC

        #region IOC Application
        //builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
        //builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
        #endregion

        #region IOC Services
        //builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
        //builder.RegisterType<IServiceProduto>().As<IServiceProduto>();
        #endregion

        #region IOC Repositorys SQL
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        #endregion

    }
}
