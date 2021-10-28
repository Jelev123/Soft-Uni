using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static  string DirectoryPath = "../../../Datasets/ Results";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            string result = GetCarsFromMakeToyota(db);
            File.WriteAllText(DirectoryPath + "toyota-cars.json",result);

            Console.WriteLine(result);
            
        }




        // 09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);


            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";


        }

        // 10. Import Parts

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(s=>s.SupplierId != null).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";



        }


        // 11. Import Cars

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }


        // 12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {

            var costumers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(costumers);
            context.SaveChanges();

            
            return $"Successfully imported {costumers.Length}.";


        }


        // 13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";

        }



        //  15. Export Cars From Make Toyota

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(s => s.Make == "Toyota")
                .Select(s => new
                {
                    Id = s.Id,
                    Make = s.Make,
                    Model = s.Model,
                    TravelledDistance = s.TravelledDistance
                })
                .OrderBy(s => s.Model)
                .ThenByDescending(s => s.TravelledDistance).ToArray();

            string json = JsonConvert.SerializeObject(cars);

            return json;
        }




    }



}