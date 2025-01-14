﻿using System.Web.Mvc;

namespace FA.JustBlog.WebCRUD.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login",controller="Post", id = UrlParameter.Optional }
            );
        }
    }
}