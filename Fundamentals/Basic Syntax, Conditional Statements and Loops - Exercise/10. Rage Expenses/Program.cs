using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displeyPrice = double.Parse(Console.ReadLine());



            double trashHeads = Math.Floor(lostGames / 2.0);
            double trashMouse = Math.Floor(lostGames / 3.0);
            double trashKeyboard = Math.Floor(lostGames / 6.0);
            double trashDispley = Math.Floor(lostGames / 12.0);

            double rageExpensive = (headsetPrice * trashHeads) + (mousePrice * trashMouse) + (keyboardPrice * trashKeyboard) + (displeyPrice * trashDispley);
            Console.WriteLine($"Rage expenses: {rageExpensive:F2} lv.");
        }
    }
    }

