using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using Remotion.Linq.Clauses.ResultOperators;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectortyPath = "../../../Datasets/Results";

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

            

            if (!Directory.Exists(ResultDirectortyPath))
            {
                Directory.CreateDirectory(ResultDirectortyPath);
            }

            string result = GetUsersWithProducts(db);


            File.WriteAllText(ResultDirectortyPath + "/users-and-products.json", result);


            Console.WriteLine(result);
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

        // 05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            var product = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(s => new
                {
                    name = s.Name,
                    price = s.Price,
                    seller = s.Seller.FirstName + " " + s.Seller.LastName
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(product,Formatting.Indented);

            return json;
        }


        //  06. Export Sold Products

        public static string GetSoldProducts(ProductShopContext context)
        {
            var product = context.Users
                .Where(s => s.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .Select(s => new
                {
                    firstname = s.FirstName,
                    lastname = s.LastName,
                    soldProducts = s.ProductsSold
                        .Where(b=> b.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                }).ToArray();


            string json = JsonConvert.SerializeObject(product,Formatting.Indented);

            return json;


        }

        // 07. Export Categories By Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(s => new
                {
                    category = s.Name,
                    productsCount = s.CategoryProducts.Count(),
                    averagePrice = s.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    totalRevenue = s.CategoryProducts.Sum(c => c.Product.Price).ToString("f2")
                })
                .OrderByDescending(s => s.productsCount)
                .ToArray();
                

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        // 08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(t => t.ProductsSold.Any(s => s.Buyer != null))
                .Select(s => new
                {
                    lastName = s.LastName,
                    age = s.Age,
                    soldProducts = new
                    {
                        count = s.ProductsSold.Count(p => p.Buyer != null),
                        products = s.ProductsSold.Where(p => p.Buyer != null)
                            .Select(d => new
                            {
                                name = d.Name,
                                price = d.Price
                            })
                            .ToArray()

                    }
                })
                .OrderByDescending(s => s.soldProducts.count)
                .ToArray();

            var resultObj = new
            {
                usersCount = users.Length,
                users = users
            };

            var setings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };


            string json = JsonConvert.SerializeObject(resultObj, setings);

            return json;
        }

    }
}