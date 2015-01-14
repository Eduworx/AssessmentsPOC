using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AssessmentsPOC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
           name: "AssessApi",
           routeTemplate: "api/Contexts/{contextId}/Assessments/{id}",
           defaults: new { controller = "Assessments", id = RouteParameter.Optional }
  );
         

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
