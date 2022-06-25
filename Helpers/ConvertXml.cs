using System.Xml;

namespace vanb.Helpers
{
    public static class ConvertXml
    {
        public static void ParseXml(this string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("item");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"{node.LocalName}-{node.InnerText}");
            }
        }
    }
}