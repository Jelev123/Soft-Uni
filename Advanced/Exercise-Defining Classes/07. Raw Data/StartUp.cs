using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    class StartUp
    {
        

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split();
                var model = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = (carInfo[4]);
               



                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tires[] tires = new Tires[4];
                int counter = 0;
                for (int j = 5; j < carInfo.Length; j+=2)
                {
                    double tire1Presure = double.Parse(carInfo[j]);
                    int tire1Age = int.Parse(carInfo[j + 1]);

                    Tires tire = new Tires(tire1Presure, tire1Age);
                    tires[counter++] = tire;
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var comands = Console.ReadLine();

            if (comands == "fragile")
            {
                var fragilecar=cars.Where(c => c.Cargo.cargoType == "fragile").Where(c => c.Tires.Any(c => c.Pressure < 1));
                foreach (var car in fragilecar)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (comands == "flamable")
            {
                var flamable = cars.Where(c => c.Cargo.cargoType == "flamable").Where(c => c.Engine.enginePower > 250);
                foreach (var car in flamable)
                {
                    Console.WriteLine(car.Model);
                }
            }

            

        }
    }
}
