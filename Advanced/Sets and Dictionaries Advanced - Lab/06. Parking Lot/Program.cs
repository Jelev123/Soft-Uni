using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {

            var parking = new HashSet<string>();
            string input = Console.ReadLine();

            while (input!= "END")
            {
                string[] cars = input.Split(", ");

                string direction = cars[0];
                string numberPlates = cars[1];
                
                if (direction == "IN")
                {
                    parking.Add(numberPlates);
                }

                if (direction== "OUT")
                {
                    parking.Remove(numberPlates);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Parking Lot is Empty");

            foreach (var cars in parking)
            {
                Console.WriteLine(cars);
            }
        }
    }
}
