using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
  public  class ExportSoldUsersDTo
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("soldProducts")]
        public ExportSoldUsersProduct[] soldProducts { get; set; }
    }

  [XmlType("Product")]
  public class ExportSoldUsersProduct
  {
      [XmlElement("name")]
      public string Name { get; set; }

      [XmlElement("price")]
      public decimal Price { get; set; }
  }
}
