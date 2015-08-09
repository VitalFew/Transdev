using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using VitalFew.Transdev.Australasia.DataPublisher.Infrastructure.Headers;

namespace VitalFew.Transdev.Australasia.DataPublisher
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: HttpClientFactory.CreatePipeline(
                                new HttpControllerDispatcher(config),
                                new DelegatingHandler[] { new AuthMessageHandler() })

            );
        }
    }
}
