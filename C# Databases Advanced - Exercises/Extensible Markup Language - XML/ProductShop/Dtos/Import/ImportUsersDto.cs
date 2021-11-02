using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
  public  class ImportUsersDto
    {
        [XmlAnyElement("firstname")]
        public string FirstName { get; set; }
        [XmlAnyElement("lastname")]
        public string LastName { get; set; }
        [XmlAnyElement("age")]
        public int Age { get; set; }
    }
}
