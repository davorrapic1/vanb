using System.Xml;
using System.Xml.Serialization;
using Models;

namespace vanb.Helpers
{
    public static class ConvertXml
    {
        public static Tecajna_lista ParseXml(this string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(Tecajna_lista));
            Tecajna_lista obj = (Tecajna_lista) serializer.Deserialize(new StringReader(xml));

            return obj;

        }
    }
}