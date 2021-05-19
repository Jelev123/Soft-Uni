using System;

namespace CarManufacturer
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Bmw";
            car.Model = "E39";
            car.Year = 2002;
            car.FuelQuantity = 70;
            car.FuelConsumption = 6.5;
            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
        }

        
    }
}
