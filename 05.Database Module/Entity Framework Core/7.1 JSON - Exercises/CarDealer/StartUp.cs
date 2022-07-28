using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTO.Supplier;

using AutoMapper;
using Newtonsoft.Json;
using CarDealer.DTO.Part;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Sale;

namespace CarDealer
{
    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(typeof(CarDealerProfile));
            });

            var contextDb = new CarDealerContext();
            InitializeDatasetFilePath("sales.json");
            var inputJson = File.ReadAllText(filePath);

            //Problem 01 -> var output = ImportSuppliers(contextDb, inputJson);
            //Problem 02 -> var output = ImportParts(contextDb, inputJson);
            //Problem 03 -> var output = ImportCars(contextDb, inputJson);
            //Problem 04 -> var output = ImportCustomers(contextDb, inputJson);
            var output = ImportSales(contextDb, inputJson);
            Console.WriteLine(output);

        }

        //Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDtos =
                JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var dto in suppliersDtos)
            {
                if (!IsValid(dto))
                {
                    continue;
                }

                var supplier = Mapper.Map<Supplier>(dto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersIds = context.Suppliers.Select(x => x.Id);

            var partDtos =
                JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson)
                .Where(x => suppliersIds.Contains(x.SupplierId));

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var dto in partDtos)
            {
                if (!IsValid(dto))
                {
                    continue;
                }

                var part = Mapper.Map<Part>(dto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            ICollection<Car> cars = new List<Car>();
            var partsIds = context.Parts.Select(x => x.Id).ToHashSet();

            foreach (var dto in carDtos)
            {
                if (!IsValid(dto))
                {
                    continue;
                }

                var car = Mapper.Map<Car>(dto);
                foreach (var partId in dto.PartsId.Distinct())
                {
                    if (partsIds.Contains(partId))
                    {
                        car.PartCars.Add(new PartCar
                        {
                            CarId = car.Id,
                            PartId = partId
                        });
                    }
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        private static void InitializeDatasetFilePath(string fileName)
        {
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }

        private static void InitializeOutputFilePath(string fileName)
        {
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customerDtos = 
                JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            var customers = new HashSet<Customer>();

            foreach (var dto in customerDtos)
            {
                if(!IsValid(dto))
                {
                    continue;
                }

                var customer = Mapper.Map<Customer>(dto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var saleDtos =
                 JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            var sales = Mapper.Map<HashSet<Sale>>(saleDtos);
            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}