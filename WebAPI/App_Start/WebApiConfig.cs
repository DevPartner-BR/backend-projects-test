using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
                //name: "DefaultApi",
                //routeTemplate: "{controller}/{id}",
                //defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
