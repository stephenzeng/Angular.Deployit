using System;

namespace Angrlar.Deployit.Web.Models
{
    public class DeploymentLog : BaseEntity
    {
        public DateTime LoggedAt { get; set; }
        public string Description { get; set; }
    }
}