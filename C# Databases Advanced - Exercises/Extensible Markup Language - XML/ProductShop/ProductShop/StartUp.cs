using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            var result = GetUsersWithProducts(db);
            File.WriteAllText("../../../Result/users-and-products.xml", result);

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


            var resultXml = XMLConverter.XmlConverter.Deserializer<CategoriesDTO>(inputXml, rootElement);


            var categories = resultXml.Where(s => s.Name != null)
                .Select(s => new Category
                {
                    Name = s.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";


        }


        // 05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {

            var rootAtribute = "Products";
            var products = context.Products
                .Where(s => s.Price >= 500 & s.Price <= 1000)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(s => s.Price)
                .Take(10)
                .ToList();

            var xmlResult = XMLConverter.XmlConverter.Serialize(products, rootAtribute);

            return xmlResult;
        }


        // 06. Export Sold Products


        public static string GetSoldProducts(ProductShopContext context)
        {
            var rootAtribute = "Users";

            var products = context.Users
                .Where(s => s.ProductsSold.Any())
                .Select(s => new ExportSoldUsersDTo
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    soldProducts = s.ProductsSold.Select(d => new ExportSoldUsersProduct
                    {
                        Name = d.Name,
                        Price = d.Price,
                    })
                        .ToArray()
                })
                .OrderBy(a => a.LastName)
                .ThenBy(r => r.FirstName)
                .Take(5)
                .ToArray();

            ;
            var xmlResult = XMLConverter.XmlConverter.Serialize(products, rootAtribute);

            return xmlResult;
        }

        // 07. Export Categories By Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var rootAtribute = "Categories";


            var productsCount = context.Categories
                .Select(s => new CategoriesByProductsCountDTO
                {
                    Name = s.Name,
                    Count = s.CategoryProducts.Count,
                    AveragePrice = s.CategoryProducts.Average(s => s.Product.Price),
                    TotalRevenue = s.CategoryProducts.Sum(s => s.Product.Price)
                })
                .OrderByDescending(s => s.Count)
                .ThenBy(s => s.TotalRevenue)
                .ToArray();

            var xmlResult = XMLConverter.XmlConverter.Serialize(productsCount, rootAtribute);

            return xmlResult;

        }


        // 08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersProducts = context.Users
                .Where(s => s.ProductsSold.Any())
                .Select(a => new Users
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Age = a.Age,
                    SolidProducts = new SolidProducts
                    {
                        Count = a.ProductsSold.Count,
                        Products = a.ProductsSold.Select(a => new Products
                        {
                            Name = a.Name,
                            Price = a.Price
                        }).OrderByDescending(s=>s.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(s => s.SolidProducts.Count)
                .Take(10)
                .ToArray();


            var users = new ExportUsersAndProductsDTO
            {
                Count = usersProducts.Length,
                Users = usersProducts
            };

            var xmlResult = XMLConverter.XmlConverter.Serialize( users,"Users");

            return xmlResult;
        }

    }
}