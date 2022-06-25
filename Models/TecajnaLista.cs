   using System.Xml.Serialization;

   namespace Models
   {
       [XmlRoot(ElementName = "item")]
       public class Item
       {
           [XmlElement(ElementName = "broj_tecajnice")]
           public string BrojTecajnice { get; set; }

           [XmlElement(ElementName = "datum_primjene")]
           public string DatumPrimjene { get; set; }

           [XmlElement(ElementName = "drzava")]
           public string Drzava { get; set; }

           [XmlElement(ElementName = "drzava_iso")]
           public string DrzavaIso { get; set; }

           [XmlElement(ElementName = "sifra_valute")]
           public string SifraValute { get; set; }

           [XmlElement(ElementName = "valuta")]
           public string Valuta { get; set; }

           [XmlElement(ElementName = "jedinica")]
           public string Jedinica { get; set; }

           [XmlElement(ElementName = "kupovni_tecaj")]
           public string KupovniTecaj { get; set; }

           [XmlElement(ElementName = "srednji_tecaj")]
           public string SrednjiTecaj { get; set; }

           [XmlElement(ElementName = "prodajni_tecaj")]
           public string ProdajniTecaj { get; set; }
       }

       [XmlRoot(ElementName = "tecajna_lista")]
       public class TecajnaLista
       {
           [XmlElement(ElementName = "item")]
           public List<Item> Item { get; set; }
       }

   }