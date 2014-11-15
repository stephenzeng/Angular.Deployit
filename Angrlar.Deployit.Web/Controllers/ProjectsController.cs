using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angrlar.Deployit.Web.Controllers
{
    public class ProjectsController : ApiHubController
    {
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
