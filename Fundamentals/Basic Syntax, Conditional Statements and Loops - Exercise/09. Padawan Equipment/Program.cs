using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabers = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            double totalPriceForSabers = lightsabers * Math.Ceiling(studentsCount * 1.1);
            double totalPriceForRobes = robes * studentsCount;
            double totalPriceForBelts = belts * studentsCount - (studentsCount / 6 * belts);
            double totalPrice = totalPriceForBelts + totalPriceForRobes + totalPriceForSabers;

            if (totalPrice <= amount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - amount:F2}lv more.");
            }
        }
    }
}
