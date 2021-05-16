using System;
using System.Collections.Generic;
using System.Linq;

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
                string name = Console.ReadLine();

                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }

            foreach (var names in set)
            {
                Console.WriteLine(names);
            }
        }
            
        }
    }


