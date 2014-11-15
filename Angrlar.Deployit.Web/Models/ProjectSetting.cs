namespace Angrlar.Deployit.Web.Models
{
    public class ProjectSetting : BaseEntity
    {
        public string TfsProjectName { get; set; }
        public string Branch { get; set; }
        public string VersionKeyName { get; set; }
        public string SourceSubFolder { get; set; }
        public string DestinationRootLocation { get; set; }
        public string DetinationProjectFolder { get; set; }
    }
}