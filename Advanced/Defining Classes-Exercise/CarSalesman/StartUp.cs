using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                Engine engine = null;

                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);

                 if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiancy = engineInfo[3];
                    engine = new Engine(model, power, efficiancy,displacement);
                }

               else if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }

               else if (engineInfo.Length == 3)
                {
                    int displacement;

                    bool isDisplacement = int.TryParse(engineInfo[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineInfo[2]);
                    }
                }
                 engines.Add(engine);

            }

            int m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                Car car = null;
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                Engine engine = engines.First(e => e.Model == carInfo[1]);

                if (carInfo.Length == 4)
                {
                    var weight = int.Parse(carInfo[2]);
                    var color = carInfo[3];
                    car = new Car(model, engine, weight, color);
                }
                else if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carInfo.Length == 3)
                {
                    int weight;

                    bool isWeight = int.TryParse(carInfo[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carInfo[2]);
                    }
                }
                cars.Add(car);
            }

            foreach (var s in cars)
            {
                Console.WriteLine(s);
            }
        }
    }
}
