using System.Collections.Generic;
using System.Linq;
using Angrlar.Deployit.Web.Models;

namespace Angrlar.Deployit.Web.Controllers
{
    public class ProjectsController : ApiHubController
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

        public void Post(ProjectSetting projectSetting)
        {
            DocSession.Store(projectSetting);
        }

        public void Delete(int id)
        {
            var projectSetting = DocSession.Load<ProjectSetting>(id);
            DocSession.Delete(projectSetting);
        }
    }
}
