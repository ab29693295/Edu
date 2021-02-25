using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Edu.Web
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                   name: "DefaultApi",
                   routeTemplate: "api/{controller}/{action}/{id}",
                   defaults: new { id = RouteParameter.Optional }
                   //defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }

                   );
        }
    }
}
