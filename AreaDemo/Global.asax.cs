using NewArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AreaDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var configuration =
                    new EmbeddedResourcePathConfiguration(
                        rootNameSpace: "NewArea",
                        viewFolderName: "Views",
                        resourceAssembly: Assembly.Load("NewArea"));
            HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedViewPathProvider(configuration));
        }
    }
}
