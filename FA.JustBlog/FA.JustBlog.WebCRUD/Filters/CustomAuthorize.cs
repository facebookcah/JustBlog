using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace FA.JustBlog.WebCRUD.Filters
{
    public class CustomAuthorize : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.Session["USER"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("/admin/Post/Login");
            }
            filterContext.Result = new RedirectResult("/Post/Index");
        }
    }
}