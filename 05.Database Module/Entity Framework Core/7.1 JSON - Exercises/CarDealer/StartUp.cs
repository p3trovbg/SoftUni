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
using AutoMapper.QueryableExtensions;

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

            var dbContext = new CarDealerContext();
            //contextDb.Database.EnsureDeleted();
            //contextDb.Database.EnsureCreated();

            InitializeOutputFilePath("sales-discounts.json");

            //Problem 01 -> var output = ImportSuppliers(dbContext, inputJson);
            //Problem 02 -> var output = ImportParts(dbContext, inputJson);
            //Problem 03 -> var output = ImportCars(dbContext, inputJson);
            //Problem 04 -> var output = ImportCustomers(dbContext, inputJson);
            //Problem 05 -> var jsonOutput = GetOrderedCustomers(dbContext);
            //Problem 06 -> var jsonOutput = GetCarsFromMakeToyota(dbContext);
            //Problem 07 -> var jsonOutput = GetLocalSuppliers(dbContext);
            //Problem 08 -> var jsonOutput = GetCarsWithTheirListOfParts(dbContext);
            //Problem 09 -> var jsonOutput = GetTotalSalesByCustomer(dbContext);
            var jsonOutput = GetSalesWithAppliedDiscount(dbContext);

            File.WriteAllText(filePath, jsonOutput);

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

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<ExportOrderedCustomerDto>()
                .ToArray();

                        
            return JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                        .Where(x => x.Make == "Toyota")
                        .OrderBy(x => x.Model)
                        .ThenByDescending(x => x.TravelledDistance)
                        .ProjectTo<ExportToyotaCarDto>()
                        .ToList();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDto>()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new 
                {
                    car = new ExportCarInfoDto
                    {
                        Make = x.Make,
                        Model = x.Model, 
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts = x.PartCars
                        .Select(x => new ExportPartInfoDto
                        {
                            Name = x.Part.Name,
                            Price = $"{x.Part.Price:f2}"
                        })
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(x => new ExportCustomerBySalesDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                                    .Sum(x => x.Car.PartCars
                                                        .Sum(x => x.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars);
         

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new ExportCarInfoDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    price = $"{x.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
                    priceWithDiscount = @$"{x.Car.PartCars.Sum(pc => pc.Part.Price) -
                                          ((x.Car.PartCars.Sum(pc => pc.Part.Price) *
                                            x.Discount) / 100):f2}"

                })
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
        private static void InitializeDatasetFilePath(string fileName)
        {
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }

        private static void InitializeOutputFilePath(string fileName)
        {
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../JsonResults/", fileName);
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