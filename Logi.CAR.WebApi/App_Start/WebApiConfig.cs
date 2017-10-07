using LogiCAR.DependencyResolver;
using Microsoft.Practices.Unity;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace LogiCAR.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Configuración y servicios de API web
            var container = new UnityContainer();
            //container.RegisterType<IBreedBusinessLogic, BreedBusinessLogic>(new HierarchicalLifetimeManager());
            ComponentLoader.LoadContainer(container, ".\\bin", "LogiCAR.*.dll");
            config.DependencyResolver = new UnityResolver(container);
            
        // Rutas de API web
        config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
           
            );

            config.Routes.MapHttpRoute(
               name: "CustomApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }

           );

            // Configuration of clients accepted types
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                              "application/xml",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/xml"));

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                             "application/json",
                             StringComparison.InvariantCultureIgnoreCase,
                             true,
                             "application/json"));

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                           "text/html",
                           StringComparison.InvariantCultureIgnoreCase,
                           true,
                           "application/json"));
        }
    }
}
