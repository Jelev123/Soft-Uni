using System;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Pesho";
            person.Age = 22;
            Console.Write(person.Name + " ");
            Console.WriteLine(person.Age);

            Person pesho = new Person();
            pesho.Name = "Pecata";
            pesho.Age = 33;
            Console.Write(pesho.Name + " ");
            Console.WriteLine(pesho.Age);

            Person gosho = new Person();
            gosho.Name = "Gosheto";
            gosho.Age = 33;
            Console.Write(gosho.Name + " ");
            Console.WriteLine(gosho.Age);



        }
    }
}
