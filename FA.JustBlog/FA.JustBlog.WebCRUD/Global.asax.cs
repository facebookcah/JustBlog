﻿using AutoMapper;
using FA.JustBlog.WebCRUD.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FA.JustBlog.WebCRUD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //autofac for DI
            AutoFacConfig.RegisterComponents();
            Mapper.Initialize(config => config.AddProfile(new AutoMapperConfig()));
        }
    }
}
