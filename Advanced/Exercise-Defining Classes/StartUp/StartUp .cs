using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Pesho";
            person.Age = 30;

            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
