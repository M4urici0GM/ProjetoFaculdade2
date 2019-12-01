using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using ProjetoFaculdade2.App_Data;

namespace ProjetoFaculdade2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            UserContext userContext = new UserContext();
            userContext.SeedUserData();
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            FriendlyUrlSettings friendlyUrlSettings = new FriendlyUrlSettings();
            friendlyUrlSettings.AutoRedirectMode = RedirectMode.Off;
            
            routes.MapPageRoute("home", "", "~/Views/Index.aspx");
            routes.MapPageRoute("login", "login", "~/Views/Login.aspx");
            routes.MapPageRoute("users", "usuarios", "~/Views/Users.aspx");
            routes.MapPageRoute("newUser", "usuarios/novo", "~/Views/NewUser.aspx");
            
            routes.EnableFriendlyUrls(friendlyUrlSettings);
            
        }
    }
}
