using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList random = new RandomList();
            random.Add("kinder");

            Console.WriteLine(random.Count);

            Console.WriteLine(random.RandomString());
        }
    }
}
