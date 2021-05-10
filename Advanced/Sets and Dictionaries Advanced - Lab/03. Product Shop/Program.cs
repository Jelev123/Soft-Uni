using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            string line;

            while ((line=Console.ReadLine()) != "Revision")
            {
                string[] info = line.Split(", ");

                string shopName = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                shops[shopName].Add(product,price);
            }

            foreach (var shop in shops.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
