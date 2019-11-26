using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ProjetoFaculdade2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            FriendlyUrlSettings friendlyUrlSettings = new FriendlyUrlSettings();
            friendlyUrlSettings.AutoRedirectMode = RedirectMode.Off;
            
            routes.MapPageRoute("home", "", "");
            routes.EnableFriendlyUrls(friendlyUrlSettings);
            
        }
    }
}
