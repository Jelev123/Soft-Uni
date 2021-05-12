using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                string[] clothes = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color,new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item,0);
                    }

                    wardrobe[color][item]++;
                }

            }

            string[] itemNeeded = Console.ReadLine().Split();

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var k in item.Value)
                {
                    Console.Write($"* {k.Key} - {k.Value}");

                    if (itemNeeded[0] == item.Key && itemNeeded[1] == k.Key)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                   

                }

            }


        }
    }
}
