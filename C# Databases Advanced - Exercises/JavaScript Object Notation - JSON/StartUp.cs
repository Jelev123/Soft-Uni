﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {


        private static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Successfuly Deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Successfuly Created");
        }

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            string result = ImportCategoryProducts(db, inputJson);
            Console.WriteLine(result);
        }


       

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";

        }


        // 02. Import Products

         public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var product = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.AddRange(product);
            context.SaveChanges();

            return $"Successfully imported {product.Length}";

        }





        // 03. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c=> c.Name != null).ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";

        }


        // 04. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {

            var catProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(catProducts);
            context.SaveChanges();

            return $"Successfully imported {catProducts.Length}";

        }
    }
}