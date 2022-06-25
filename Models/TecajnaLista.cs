   /* 
       Licensed under the Apache License, Version 2.0
       
       http://www.apache.org/licenses/LICENSE-2.0
       */

   using System.Xml.Serialization;

   namespace Models
   {
       [XmlRoot(ElementName = "item")]
       public class Item
       {
           [XmlElement(ElementName = "broj_tecajnice")]
           public string Broj_tecajnice { get; set; }

           [XmlElement(ElementName = "datum_primjene")]
           public string Datum_primjene { get; set; }

           [XmlElement(ElementName = "drzava")]
           public string Drzava { get; set; }

           [XmlElement(ElementName = "drzava_iso")]
           public string Drzava_iso { get; set; }

           [XmlElement(ElementName = "sifra_valute")]
           public string Sifra_valute { get; set; }

           [XmlElement(ElementName = "valuta")]
           public string Valuta { get; set; }

           [XmlElement(ElementName = "jedinica")]
           public string Jedinica { get; set; }

           [XmlElement(ElementName = "kupovni_tecaj")]
           public string Kupovni_tecaj { get; set; }

           [XmlElement(ElementName = "srednji_tecaj")]
           public string Srednji_tecaj { get; set; }

           [XmlElement(ElementName = "prodajni_tecaj")]
           public string Prodajni_tecaj { get; set; }
       }

       [XmlRoot(ElementName = "tecajna_lista")]
       public class Tecajna_lista
       {
           [XmlElement(ElementName = "item")]
           public List<Item> Item { get; set; }
       }

   }