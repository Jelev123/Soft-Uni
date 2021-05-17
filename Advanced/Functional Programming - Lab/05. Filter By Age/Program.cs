using System;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var person = new Dictionary<string, List<int>>();
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string conditional = Console.ReadLine();
            string format = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                if (!person.ContainsKey(name))
                {
                    person.Add(name,new List<int>());
                }

                if (!person[name].Contains(age))
                {
                    person[name].Add(age);
                }

                person[name][age]++;
                

                if (conditional == "older")
                {
                    if (format == "name age")
                    {
                        if (age >= 20)
                        {
                            Console.WriteLine($"{name} - {age}");
                        }
                    }
                }
            }

          
        }
    }
}
