using System;


namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Kalpazan";
            person.Age = 2;
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
