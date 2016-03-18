using ExemploAgenda.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExemploAgenda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
