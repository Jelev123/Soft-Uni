using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Common;
using Vehicle.Models;

namespace Vehicle.Factories
{
  public  class VehicleFactory
  {
      public   Vehicle ProducedVehicle (string type, double fuelQuantity, double fuelConsumtion)
      {
          Vehicle vehicle = null;

          if (type == "Car")
          {
              vehicle = new Car(fuelQuantity, fuelConsumtion);

          }
          else if (type == "Truck")
          {
              vehicle = new Truck(fuelQuantity, fuelConsumtion);
          }
          else if (vehicle == null)
          {
              throw new ArgumentException(ExceptionMesage.VehicleExcpMessage);
          }

          return vehicle;
      }
  }
}
