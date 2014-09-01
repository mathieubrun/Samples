﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Samples.Web.EmbeddedResourceDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "EmbeddedResourceDemo",
                routeTemplate: "EmbeddedResourceDemoData/{*path}",
                defaults: null,
                constraints: null,
                handler: new EmbeddedResourceHandler("Samples.Web.EmbeddedResourceDemo.Data"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
