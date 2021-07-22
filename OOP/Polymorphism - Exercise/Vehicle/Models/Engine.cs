
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Vehicle.Factories;
using Vehicle.Models.Contracts;

namespace Vehicle.Models
{
   public class Engine : IEngine
    {
        #region Implementation of IEngine

        private VehicleFactory viFactory;
        public Engine()
        {
            this.viFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle carVehicle = ProduceVehicle();
            Vehicle tVehicle = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < n; i++)
                {
                    string[] commands = Console.ReadLine().Split();

                    string commType = commands[0];
                    string vehicleType = commands[1];
                    double args = double.Parse(commands[2]);

                    if (commType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            carVehicle.Drive(args);
                        }
                       else if (vehicleType == "Truck")
                        {
                            tVehicle.Drive(args);
                        }
                    }
                    else if (commType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            carVehicle.Refuel(args);
                        }
                        else if (vehicleType == "Truck")
                        {
                            tVehicle.Refuel(args);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }

       

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelCons = double.Parse(vehicleArgs[2]);

            Vehicle truckVehicle = this.viFactory.ProducedVehicle(type, fuelQuantity, fuelCons);

            Console.WriteLine(truckVehicle);
            return truckVehicle;
        }

        #endregion

     

       
    }

   
}
