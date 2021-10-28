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


        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            var json = File.ReadAllText("../../../Datasets/customers.json");

            var result = ImportCustomers(db, json);

            Console.WriteLine(result);


        }




        // 09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);


            context.Suppliers.AddRange();
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";


        }

        // 10. Import Parts

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(s=>s.SupplierId != null).ToArray();

            context.Parts.AddRange();
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";



        }


        // 11. Import Cars

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            context.Cars.AddRange();
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }


        // 12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {

            var costumers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange();
            context.SaveChanges();

            
            return $"Successfully imported {costumers.Length}.";


        }
    }



}