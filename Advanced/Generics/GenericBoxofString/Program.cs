
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using GenericBoxOfString;

namespace GenericBoxofString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                Box<string> input = new Box<string>(name);
                Console.WriteLine(input.ToString());
            }
                                      
        }
    }
}
