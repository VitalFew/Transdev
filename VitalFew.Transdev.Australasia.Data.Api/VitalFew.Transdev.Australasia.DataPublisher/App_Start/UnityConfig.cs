using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using VitalFew.Transdev.Australasia.DataPublisher.Providers;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IAuthorizationProvider, AuthorizationProvider>();
            container.RegisterType<IConfigurationProvider, ConfigurationProvider>();
            container.RegisterType<IDataProvider, DataProvider>();
            container.RegisterType<ICatalogClientProvider, CatalogClientProvider>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}