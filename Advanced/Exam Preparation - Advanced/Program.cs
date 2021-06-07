using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
           
               var firstBox = new Queue<int>(Console.ReadLine().Split()
                .Select(int.Parse).ToList());

               Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split()
                   .Select(int.Parse).ToList());

               var claimed = new List<int>();

               while (firstBox.Count > 0 && secondBox.Count > 0 )
               {
                   int box1 = firstBox.Peek();
                   int box2 = secondBox.Peek();
                   int sum = box1 + box2;
                   
                   if (sum % 2 == 0)
                   {
                       claimed.Add(firstBox.Dequeue() + secondBox.Pop());
                   }
                   else
                   {
                       firstBox.Enqueue(secondBox.Pop());
                   }


                   if (firstBox.Count <= 0)
                   {
                       Console.WriteLine("First lootbox is empty");
                   }
                   else if (secondBox.Count <= 0)
                   {
                       Console.WriteLine("Second lootbox is empty");
                   }

            }

               if (claimed.Sum() >= 100)
               {
                   Console.WriteLine($"Your loot was epic! Value: {claimed.Sum()}");
               }
               else
               {
                   Console.WriteLine($"Your loot was poor... Value: {claimed.Sum()}");
               }
               


        }


    }
    }

