using System.Xml.Serialization;
using Models;

namespace Helpers
{
    public static class ConvertXml
    {
        public static TecajnaListaXML ParseXml(this string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TecajnaListaXML));
            return (TecajnaListaXML) serializer.Deserialize(new StringReader(xml));
        }
    }
}