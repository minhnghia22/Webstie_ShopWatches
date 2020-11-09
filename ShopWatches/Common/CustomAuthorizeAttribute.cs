using ShopWatches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWatches.Common
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
         public string Role { set; get; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (Employee)HttpContext.Current.Session["userLogin"];
            if (session == null)
            {
                return false;
            }

            if (session.Role.name == this.Role)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Admin/Auth/login");

        }
    }
}