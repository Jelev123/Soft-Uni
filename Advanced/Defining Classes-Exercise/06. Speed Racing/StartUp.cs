using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Speed_Racing
{
  public  class Program
    {
        static void Main(string[] args)
        {
            var cars = new HashSet<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumptionFor1km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var input = command.Split();
                var model = input[1];
                int amountOfKm = int.Parse(input[2]);
                

                Car car = cars.FirstOrDefault(c => c.Model == model);
                car.Drive(amountOfKm);


                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
