using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CarDealer.Data;
using CarDealer.Models;

using AutoMapper;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var contextDb = new CarDealerContext();

            //contextDb.Database.EnsureDeleted();
            //contextDb.Database.EnsureCreated();

            //Console.WriteLine("Create succesfully!");
        }
    }
}