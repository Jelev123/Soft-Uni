using System;
using System.Collections.Generic;
using System.Linq;
using _04._Border_Control;

namespace Border_Control
{
   public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

           

            var all = new List<IId>();

            while (command != "End")
            {
                var tokens = command.Split();

                if (tokens.Length == 3)
                {
                    all.Add(new Citizens(tokens[0],int.Parse(tokens[1]),tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    all.Add(new Robots(tokens[0], tokens[1]));
                }


                command = Console.ReadLine();
            }

            var lastDigits = Console.ReadLine();

            all.Where(c=>c.Id.EndsWith(lastDigits))
                .Select(c=>c.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
