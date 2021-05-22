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

            List<Person> man = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                man.Add(person);


            }
            var people = man.Where(p => p.Age > 30).ToList().OrderBy(p => p.Name);

            foreach (var person in people )
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
