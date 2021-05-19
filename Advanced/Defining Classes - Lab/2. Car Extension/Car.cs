using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double FuelQuantity { get; set; }

        public double fuelConsumption { get; set; }


        public void Drive(double distance)
        {
            double fuel = FuelQuantity - distance;

            if (fuel * FuelQuantity <= 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");

            }
            else
            {
                FuelQuantity -= fuel;

            }
        }

        public string WhoAmI()
        {
            return $"Make: { this.Make}\nModel: { this.Model}\nYear: { this.Year}\nFuel: { this.FuelQuantity:F2} L";
        }
    }
}

    
