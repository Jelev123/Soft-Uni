using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var world = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                var continents = info[0];
                var countries = info[1];
                var cities = info[2];

                if (!world.ContainsKey(continents))
                {
                    world.Add(continents,new Dictionary<string, List<string>>());
                }

                if (!world[continents].ContainsKey(countries))
                {
                    world[continents].Add(countries,new List<string>());
                }
                world[continents][countries].Add(cities);
            }

            foreach (var kvp in world)
            {
                Console.WriteLine($"{kvp.Key}: ");

                foreach (var abc in kvp.Value)
                {
                    Console.WriteLine($"{abc.Key} -> {string.Join(", ",abc.Value)}");
                }
            }
        }
    }
}
