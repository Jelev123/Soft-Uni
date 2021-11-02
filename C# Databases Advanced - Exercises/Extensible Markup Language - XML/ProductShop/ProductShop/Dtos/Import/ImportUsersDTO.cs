using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class ImportUsersDTO
    {
        [XmlElement("firstname")]
        public string FirstName { get; set; }
        [XmlElement("lastname")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }
    }
}
