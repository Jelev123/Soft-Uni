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

            string json = File.ReadAllText("../../../Datasets/suppliers.json");

          string result=  ImportSuppliers(db,json);

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
    }
}