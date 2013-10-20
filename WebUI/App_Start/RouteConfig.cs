﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("MonthRoute", "Wallet/Month/{year}/{month}",
                            new
                                {
                                    controller = "Wallet",
                                    action = "Month",
                                    year = UrlParameter.Optional,
                                    month = UrlParameter.Optional
                                }
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}