using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SupportPage
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //SiteMap.SiteMapResolve += SiteMap_SiteMapResolve;
        }      
        
        //SiteMapNode SiteMap_SiteMapResolve(object sender, SiteMapResolveEventArgs e)
        //{
        //    SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
        //    SiteMapNode tempNode = currentNode;

        //    //if (SiteMap.CurrentNode.Url.Contains(""))
        //}
    }
}