using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Speed_Racing
{
   public class Car
   {
      
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int amountOfKm)
        {
            double neededLiters = FuelConsumptionPerKilometer * amountOfKm;
            bool canMoove = FuelAmount - neededLiters >= 0;
            if (canMoove)
            {
                FuelAmount -= neededLiters;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }


        }
    }
}
