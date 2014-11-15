using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Angrlar.Deployit.Web.Common;
using Angrlar.Deployit.Web.Hubs;
using Angrlar.Deployit.Web.Models;
using Microsoft.VisualBasic.FileIO;

namespace Angrlar.Deployit.Web.Controllers
{
    public class DeployController : ApiHubController<BroadcastHub>
    {
        public HttpResponseMessage Post(DeployRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Project))
                {
                    NotifyAndLog("Deployment request is rejected because of invalid data");
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }

                request.CreatedAt = DateTime.Now;

                NotifyAndLog("Deployment request received for project '{0}'", request.Project);
                ProcessDeployment(request);

                request.DeploySucceeded = true;

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                NotifyAndLog(ex.Message);
                NotifyAndLog(ex.StackTrace);
                //todo: rollback process

                if (request != null) request.DeploySucceeded = false;

                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                if (request != null) DocSession.Store(request);
            }
        }

        private void ProcessDeployment(DeployRequest model)
        {
            //Backup
            var backupFolder = Path.Combine(model.DestinationRootLocation, "_Backup",
                string.Format("{0}_{1}", model.DestinationProjectFolder, DateTime.Now.ToString("yyyyMMdd_hhmmss")));
            var projectPath = Path.Combine(model.DestinationRootLocation, model.DestinationProjectFolder);

            NotifyAndLog("Copying folder {0} to {1}...", projectPath, backupFolder);
            FileSystem.CopyDirectory(projectPath, backupFolder);

            //Copy files to project folder
            var source = Path.Combine(model.BuildDropLocation, model.PublishedWebsiteFolder);

            NotifyAndLog("Deploying files from folder {0} to {1}...", source, projectPath);
            FileSystem.CopyDirectory(source, projectPath, true);

            //copy web.config
            var sourceConfig = Path.Combine(backupFolder, "Web.config");
            var destConfig = Path.Combine(projectPath, "Web.config");

            NotifyAndLog("Copying {0} to {1}...", sourceConfig, destConfig);
            FileSystem.CopyFile(sourceConfig, destConfig, true);

            //update version number
            NotifyAndLog("Update application version number [{0}] to {1}", model.VersionKeyName, model.NextVersion);
            Helper.SetVersionNumber(destConfig, model.VersionKeyName, model.NextVersion);

            NotifyAndLog("Deployment process completed");
        }

        private void NotifyAndLog(string message, params object[] args)
        {
            var text = string.Format(message, args);

            Broadcast(text);
            DocSession.Store(new DeploymentLog
            {
                CreatedBy = User.Identity.Name,
                LoggedAt = DateTime.Now,
                Description = text,
            });
        }
    }
}