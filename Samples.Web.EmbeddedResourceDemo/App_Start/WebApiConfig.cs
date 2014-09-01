using Samples.Web.EmbeddedResourceDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Samples.Web.EmbeddedResourceDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            DelegatingHandler[] handlers = new DelegatingHandler[] {
                new  EmbeddedResourceHandler(typeof(Class1).Assembly)
            };

            var routeHandlers = HttpClientFactory.CreatePipeline(new HttpControllerDispatcher(config), handlers);


            config.Routes.MapHttpRoute(
                name: "EmbeddedResourceDemo",
                routeTemplate: "EmbeddedResourceDemoData/{*path}",
                defaults: null,
                constraints: null,
                handler: routeHandlers);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
