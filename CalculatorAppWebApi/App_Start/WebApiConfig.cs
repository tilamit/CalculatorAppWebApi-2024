using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.WebHost;

namespace CalculatorAppWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "GET, POST");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();
            // Web API configuration and services
            //config.Filters.Add(new AuthorizeAttribute());

            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",
       System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null,
                    new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.CreateDefaultSerializerSettings();

            // Web API configuration and services
            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
