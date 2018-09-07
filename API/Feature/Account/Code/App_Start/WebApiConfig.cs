using Api.Feature.Account.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Feature.Account.Infrastructure.Filter;
using Newtonsoft.Json;

namespace Code
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            ///config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            ///    defaults: new { id = RouteParameter.Optional }
            ///);
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            config.MessageHandlers.Add(new AuthHandler());
            config.Filters.Add(new ValidateModelAttribute());

            log4net.Config.XmlConfigurator.Configure();

            // Web API configuration and services
            ///config.Formatters.Clear();
           ///config.Formatters.Add(new JsonMediaTypeFormatter());
            var formatter = config.Formatters.JsonFormatter;

            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            formatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            formatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy/MM/dd HH:mm:ss"
                }
            );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
