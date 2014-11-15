using System;
using Microsoft.AspNet.SignalR;

namespace Angrlar.Deployit.Web.Controllers
{
    public abstract class ApiHubController<T> : ApiControllerBase where T : Hub
    {
        private static readonly Lazy<IHubContext> Lazy = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<T>());
        protected IHubContext HubContext { get { return Lazy.Value; } }

        protected void Broadcast(string message)
        {
            HubContext.Clients.All.broadcast(message);
        }
    }
}