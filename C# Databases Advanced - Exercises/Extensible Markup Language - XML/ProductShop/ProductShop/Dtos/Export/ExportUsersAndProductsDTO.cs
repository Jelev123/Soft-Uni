using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUsersAndProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlElement("users")]

        public Users[] Users { get; set; }


    }
    [XmlType("User")]
    public class Users
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SolidProducts")]
        public SolidProducts SolidProducts { get; set; }
    }


    public class SolidProducts
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public Products[] Products { get; set; }
    }

    [XmlType("Product")]

    public class Products
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

