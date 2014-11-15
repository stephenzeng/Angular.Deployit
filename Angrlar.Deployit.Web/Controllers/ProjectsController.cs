using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Angrlar.Deployit.Web.Models;

namespace Angrlar.Deployit.Web.Controllers
{
    public class ProjectsController : ApiControllerBase
    {
        public IEnumerable<ProjectSetting> Get()
        {
            return DocSession.Query<ProjectSetting>()
                .OrderByDescending(p => p.CreatedAt);
        }

        public ProjectSetting Get(int id)
        {
            return DocSession.Load<ProjectSetting>(id);
        }

        [HttpPost]
        public void Post(ProjectSetting projectSetting)
        {
            DocSession.Store(projectSetting);
        }

        [HttpPost]
        public void Delete(int id)
        {
            var projectSetting = DocSession.Load<ProjectSetting>(id);
            DocSession.Delete(projectSetting);
        }
    }
}
