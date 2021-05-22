using System;
using System.Collections.Generic;
using System.Linq;
using Define_a_Class_Person;


namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Pesho";
            person.Age = 20;
            Console.WriteLine($"{person.Name} {person.Age}");

        }



    }
    }

