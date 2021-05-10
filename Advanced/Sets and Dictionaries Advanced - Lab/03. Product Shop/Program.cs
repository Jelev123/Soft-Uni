using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < shops.Count; i++)
            {
                string[] info = Console.ReadLine().Split();

                string shopName = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName,new Dictionary<string, double>());
                }
                shops[shopName].Add(product,price);
            }

            foreach (var kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}->");
            }
        }
    }
}
