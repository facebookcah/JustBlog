﻿using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebCRUD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
