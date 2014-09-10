using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using BusBookingSystem.WebApi.Core;

namespace BusBookingSystem.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

            //config.Routes.MapHttpRoute(
            //    name: "BookingAdd",
            //    routeTemplate: "Booking/Add",
            //    defaults: new
            //    {
            //        title = RouteParameter.Optional,
            //        controller = "Booking",
            //        action = "Add"
            //    },
                
            //);

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
