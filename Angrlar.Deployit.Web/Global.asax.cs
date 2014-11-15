using System.Web;
using System.Web.Http;
using Raven.Client;
using Raven.Client.Document;

namespace Angrlar.Deployit.Web
{
    public class WebApiApplication : HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

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
