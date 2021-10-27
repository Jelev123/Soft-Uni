using System;
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
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            string inputJson = File.ReadAllText("../../../Datasets/users.json");

            string result = ImportUsers(db, inputJson);
            Console.WriteLine(result);
        }


        private static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Successfuly Deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Successfuly Created");
        }



        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";

        }
    }
}