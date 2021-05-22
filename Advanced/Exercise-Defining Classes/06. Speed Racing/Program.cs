using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Speed_Racing
{
  public  class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string model = inputInfo[0];
                double fuelAmount = double.Parse(inputInfo[1]);
                double fuelConsumption = double.Parse(inputInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split();

                string model = data[1];
                int fuelAmount = int.Parse(data[2]);
               

                Car car = cars.FirstOrDefault(x => x.Model == model);

                car.Drive(fuelAmount);

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

           
        }
    }
}
