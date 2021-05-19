using System;
using _1._Car;

namespace CarManufacturer

{
    public class StartUp
    {
       public static void Main(string[] args)
       {
           var car = new Car();
           car.Make = "BMW";
           car.Model = "E39";
           car.Year = "2002";

           Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
           

       }
    }
}
