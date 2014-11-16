using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using Angrlar.Deployit.Web.Models;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;

namespace Angrlar.Deployit.Web.Controllers
{
    public class TfsController : ApiController
    {
        private readonly Uri _tfsUri;

        public TfsController()
        {
            _tfsUri = new Uri(ConfigurationManager.AppSettings["TfsUrl"]);
        }

        public IEnumerable<BuildInfoModel> GetLastBuildList(string projectName, string branch, int size)
        {
            var tfs = new TfsTeamProjectCollection(_tfsUri);

            var buildServer = tfs.GetService<IBuildServer>();

            var lastBuildList = buildServer.QueryBuilds(projectName)
                .Where(b => b.BuildDefinition.Name == branch)
                .OrderByDescending(b => b.FinishTime)
                .Take(size)
                .Select(b => new BuildInfoModel()
                {
                    Project = b.TeamProject,
                    Branch = b.BuildDefinition.Name,
                    BuildNumber = b.BuildNumber,
                    Status = b.Status,
                    FinishTime = b.FinishTime,
                    RequestedBy = b.RequestedFor,
                    Changeset = b.SourceGetVersion,
                    DropLocation = b.DropLocation,
                });

            return lastBuildList;
        }
    }
}