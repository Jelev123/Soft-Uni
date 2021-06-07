using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                persons.Add(new Person(name, age));
            }

            var man = persons.Where(p => p.Age > 30).OrderBy(x => x.Name);

            foreach (var person in man)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
