using Angrlar.Deployit.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Angrlar.Deployit.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.MapSignalR();
        }
    }
}