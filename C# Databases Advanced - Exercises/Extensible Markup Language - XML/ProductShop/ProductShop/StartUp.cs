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

            var xmlFile = File.ReadAllText("../../../Datasets/products.xml");

            var result = ImportProducts(db, xmlFile);

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



        // 02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var rootElement = "Products";

            var resulXml = XMLConverter.XmlConverter.Deserializer<ImportProductsDTO>(inputXml, rootElement);

            var products = resulXml
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                }).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";

        }


    }
}