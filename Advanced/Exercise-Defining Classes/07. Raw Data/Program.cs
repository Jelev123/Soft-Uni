using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                int counter = 0;

                for (int j = 5; j < carInfo.Length; j+=2)
                {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    tires[counter++] = tire;
                }

                Car car = new Car(model, engine, cargo,tires);
                cars.Add(car);

            }

            string input = Console.ReadLine();
            if (input == "fragile")
            {
                var fragileCars = cars.Where(c => c.Cargo.cargoType == "fragile" &&
                                                  c.Tires.Any(p=>p.Pressure<1)).ToList();

                foreach (var fragileCar in fragileCars)
                {
                    Console.WriteLine(fragileCar.Model);
                }
            }
            else if (input == "flamable")
            {
                var flamableCar = cars.Where(p => p.Engine.enginePower > 250).ToList();

                foreach (var flame in flamableCar)       
                {
                    Console.WriteLine(flame.Model);
                }
            }




        }
    }
}
