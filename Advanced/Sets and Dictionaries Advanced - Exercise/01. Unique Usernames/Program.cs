using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string names = Console.ReadLine();

                if (!set.Contains(names))
                {
                    set.Add(names);
                }
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
            
        }
    }
}
