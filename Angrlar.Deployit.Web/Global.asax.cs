using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace Angrlar.Deployit.Web
{
    public class WebApiApplication : HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDocumentStore();
        }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore == null)
            {
                DocumentStore = new DocumentStore
                {
                    ConnectionStringName = "RavenDB"
                }.Initialize();
            }
        }
    }
}
