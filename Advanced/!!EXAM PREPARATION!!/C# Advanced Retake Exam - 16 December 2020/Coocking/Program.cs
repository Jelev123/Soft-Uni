using System;
using System.Collections.Generic;
using System.Linq;

namespace Coocking
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquidQueue = new Queue<int>(Console.ReadLine().Split()
                .Select(int.Parse));
            var ingredientStack = new Stack<int>(Console.ReadLine().Split()
                .Select(int.Parse));

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            bool isSucceeded = false;

            while (liquidQueue.Count > 0 && ingredientStack.Count > 0)
            {
                int currLiquid = liquidQueue.Peek();
                int currIngredient = ingredientStack.Peek();
                int sum = currLiquid + currIngredient;
                if (sum == 25)
                {
                    bread++;
                    liquidQueue.Dequeue();
                    ingredientStack.Pop();

                }


                else if (sum == 50)
                {
                    cake++;
                    liquidQueue.Dequeue();
                    ingredientStack.Pop();


                }
                else if (sum == 75)
                {
                    pastry++;
                    liquidQueue.Dequeue();
                    ingredientStack.Pop();


                }
                else if (sum == 100)
                {
                    fruitPie++;
                    liquidQueue.Dequeue();
                    ingredientStack.Pop();


                }
                else
                {
                    liquidQueue.Dequeue();
                    ingredientStack.Pop();
                    ingredientStack.Push(currIngredient + 3);

                }


            }




            if (liquidQueue.Count == 0 && ingredientStack.Count == 0)
            {
                isSucceeded = true;


            }

            if (isSucceeded)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food");
                Console.WriteLine("Liquids left: none");
                Console.WriteLine("Ingredients left: none");
                Console.WriteLine($"Bread: {bread}");
                Console.WriteLine($"Cake: {cake}");
                Console.WriteLine($"Fruit pie: {fruitPie}");
                Console.WriteLine($"Pastry: {pastry}");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
                Console.WriteLine("Liquids left: none");
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientStack)}");
                Console.WriteLine($"Bread: {bread}");
                Console.WriteLine($"Cake: {cake}");
                Console.WriteLine($"Fruit pie: {fruitPie}");
                Console.WriteLine($"Pastry: {pastry}");
            }






        }
    }
}

