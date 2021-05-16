using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    line = line.Replace(",", "@");
                    line = line.Replace(".", "@");
                    line = line.Replace("?", "@");
                    line = line.Replace("!", "@");
                    line = line.Replace("-", "@");
                    

                    if (counter % 2 == 0)
                    {
                        var array = line.Split().Reverse().ToArray();
                        Console.WriteLine(string.Join(" ",array));
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
