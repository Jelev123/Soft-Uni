using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] price = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(x=>x*1.2m)
                .ToArray();

            foreach (var vat in price)
            {
                Console.WriteLine(($"{vat:F2}"));
            }
            
        }           
    }
}
