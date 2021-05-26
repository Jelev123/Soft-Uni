
using System;
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
                string input = Console.ReadLine();
                Box<string> text = new Box<string>(input);
                Console.WriteLine(text.ToString());
            }
        }
    }
}
