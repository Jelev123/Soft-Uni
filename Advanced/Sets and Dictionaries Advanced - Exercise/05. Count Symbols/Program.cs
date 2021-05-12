using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            var text = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!text.ContainsKey(input[i]))
                {
                    text.Add(input[i],0);
                }

                
            }


            foreach (var i in text.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{i.Key}: {i.Value} time/s");
            }
        }
    }
}
