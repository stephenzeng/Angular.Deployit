using System.ComponentModel;

namespace Angrlar.Deployit.Web.Models
{
    public class DeployRequest : BaseEntity
    {
        public string Project { get; set; }

        [DisplayName("Build drop location")]
        public string BuildDropLocation { get; set; }

        [DisplayName("Website build drop folder")]
        public string PublishedWebsiteFolder { get; set; }

        [DisplayName("Destination location")]
        public string DestinationRootLocation { get; set; }

        [DisplayName("Destination project folder")]
        public string DestinationProjectFolder { get; set; }

        [DisplayName("Current version")]
        public string CurrentVersion { get; set; }

        [DisplayName("Next version")]
        public string NextVersion { get; set; }

        public string VersionKeyName { get; set; }
        public bool? DeploySucceeded { get; set; }
    }
}