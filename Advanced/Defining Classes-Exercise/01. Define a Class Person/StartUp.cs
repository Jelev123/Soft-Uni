using System;
using System.Threading.Channels;

namespace DefiningClasses

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Kinder";
            person.Age = 2;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);


        }
        
    }
}
