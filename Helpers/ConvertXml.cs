using System.Xml;
using System.Xml.Serialization;
using Models;

namespace vanb.Helpers
{
    public static class ConvertXml
    {
        public static TecajnaLista ParseXml(this string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(TecajnaLista));
            return (TecajnaLista) serializer.Deserialize(new StringReader(xml));

        }
    }
}