using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

            var xmlFile = File.ReadAllText("../../../Datasets/categories.xml");

            var result = ImportCategories(db, xmlFile);

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



        // 03. Import Categories



        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var rootElement = "Categories";


            var resultXml =XMLConverter.XmlConverter.Deserializer<CategoriesDTO>(inputXml, rootElement);


            var categories = resultXml.Where(s => s.Name != null)
                .Select(s=> new Category
                {
                    Name = s.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";


        }


    }
}