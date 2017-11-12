using RSAWebSideRedirectorPage.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RSAWebSideRedirectorPage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static RSAHelper RsaHelperTool = new RSAHelper();
        public static RSAWebSideRedirectorPage.Models.LoginViewModel pulbicKeyList;
        public static string PrivateKey;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
