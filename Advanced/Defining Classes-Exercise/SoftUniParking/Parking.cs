using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private Dictionary<string,Car> cars;
        public Parking( int capacity)
        {
            this.cars = new Dictionary<string, Car>();
           this.capacity = capacity;
        }

        public int Count
        {
            get => cars.Count;
        }

       

       public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";

            }
            else
            {
                cars.Add(car.RegistrationNumber,car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

            }

        }

       public string RemoveCar(string registrationNumber)
       {
           if (!cars.ContainsKey(registrationNumber))
           {
               return "Car with that registration number, doesn't exist!";

           }
           else
           {
               cars.Remove(registrationNumber);
               return $"Successfully removed {registrationNumber}";

           }
        }
       public  Car GetCar(string registrationNumber)
       {
           return this.cars[registrationNumber];
       }

       public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
       {
           foreach (var registrationNumber in registrationNumbers)
           {
               this.RemoveCar(registrationNumber);
           }
       }




    }
}