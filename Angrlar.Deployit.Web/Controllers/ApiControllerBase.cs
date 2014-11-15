using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;

namespace Angrlar.Deployit.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IDocumentSession DocSession { get; private set; }
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            if (DocSession == null) DocSession = WebApiApplication.DocumentStore.OpenSession();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (DocSession != null)
            {
                using (DocSession)
                {
                    DocSession.SaveChanges();
                }
            }
        }
    }
}