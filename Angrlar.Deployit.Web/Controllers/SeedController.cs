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
                new ProjectSetting {TfsProjectName = "DSC.SeedProjectA", Branch = "Main", DestinationRootLocation = @"//testapp01/apps/", DetinationProjectFolder = "SeedA_Main", SourceSubFolder = "PublsihedWebSite", CreatedAt = DateTime.Now},
                new ProjectSetting {TfsProjectName = "DSC.SeedProjectB", Branch = "Main", DestinationRootLocation = @"//testapp01/apps/", DetinationProjectFolder = "SeedB_Main", SourceSubFolder = "PublsihedWebSite", CreatedAt = DateTime.Now},
                new ProjectSetting {TfsProjectName = "DSC.SeedProjectC", Branch = "Main", DestinationRootLocation = @"//testapp01/apps/", DetinationProjectFolder = "SeedC_Main", SourceSubFolder = "PublsihedWebSite", CreatedAt = DateTime.Now},
                new ProjectSetting {TfsProjectName = "DSC.SeedProjectD", Branch = "Main", DestinationRootLocation = @"//testapp01/apps/", DetinationProjectFolder = "SeedD_Main", SourceSubFolder = "PublsihedWebSite", CreatedAt = DateTime.Now},
            };

            projects.ForEach(DocSession.Store);
        }
    }
}