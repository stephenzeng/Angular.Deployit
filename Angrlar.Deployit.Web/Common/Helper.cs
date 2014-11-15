using System.Xml;

namespace Angrlar.Deployit.Web.Common
{
    public static class Helper
    {
       public static string ReadVersionNumber(string configFile, string versionKeyName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);

            var node = xmlDoc.SelectSingleNode(string.Format("//add[@key='{0}']", versionKeyName));
            return node != null ? node.Attributes["value"].Value : string.Empty;
        }

        public static void SetVersionNumber(string configFile, string versionKeyName, string value)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);

            var node = xmlDoc.SelectSingleNode(string.Format("//add[@key='{0}']", versionKeyName));
            if (node != null) node.Attributes["value"].Value = value;

            xmlDoc.Save(configFile);
        }
    }
}