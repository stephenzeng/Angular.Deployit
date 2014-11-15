using System;
using Angrlar.Deployit.Web.Models;
using Raven.Abstractions.Extensions;

namespace Angrlar.Deployit.Web.Controllers
{
    public class SeedController : ApiControllerBase
    {
        public void Get()
        {
            var projects = new[]
            {
                new ProjectSetting {TfsProjectName = "DSC.SEEDA", CreatedAt = DateTime.Now},
                new ProjectSetting {TfsProjectName = "DSC.SEEDB", CreatedAt = DateTime.Now},
                new ProjectSetting {TfsProjectName = "DSC.SEEDC", CreatedAt = DateTime.Now},
            };

            projects.ForEach(DocSession.Store);
        }
    }
}