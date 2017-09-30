using LogiCAR.DependencyResolver;
using Microsoft.Practices.Unity;
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
        }
    }
}
