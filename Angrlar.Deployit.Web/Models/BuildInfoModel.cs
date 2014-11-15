using System;
using Microsoft.TeamFoundation.Build.Client;

namespace Angrlar.Deployit.Web.Models
{
    public class BuildInfoModel
    {
        public string Project { get; set; }
        public string Branch { get; set; }
        public string BuildNumber { get; set; }
        public BuildStatus Status { get; set; }
        public DateTime FinishTime { get; set; }
        public string RequestedBy { get; set; }
        public string Changeset { get; set; }
        public string DropLocation { get; set; }
    }
}