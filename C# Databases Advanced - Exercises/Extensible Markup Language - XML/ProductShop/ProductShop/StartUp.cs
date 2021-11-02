using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            var xml = File.ReadAllText("../../../Datasets/users.xml");

            var result = ImportUsers(db, xml);

            Console.WriteLine(result);

        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var resultXml = XMLConverter.XmlConverter.Deserializer<ImportUsersDTO>(inputXml, rootElement);

            var users = resultXml
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToArray();


            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";

        }




    }
}