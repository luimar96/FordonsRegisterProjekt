using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VehicleDomain.Vehicle.Interfaces;
using VehicleRepository;
using VehicleRepository.Interfaces;

namespace FordonsregistretProjekt
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static void RegisterSimpelInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IVehicleRepository, AzureStorage>(Lifestyle.Scoped);
            container.Register<IServiceRepository, AzureStorage>(Lifestyle.Scoped);
            container.Register<IVehicleService, AzureStorage>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration); container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
