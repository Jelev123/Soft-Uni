using System;
using System.IO;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json.Converters;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;


namespace ProductShop
{

    

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            ResetDatabase(db);


        }


        static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }



       




    }
}