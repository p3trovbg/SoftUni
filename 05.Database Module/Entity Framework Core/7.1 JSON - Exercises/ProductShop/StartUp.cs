namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;

    using Data;
    using DTOs.User;
    using Models;

    using AutoMapper;
    using Newtonsoft.Json;
    using ProductShop.DTOs.Product;
    using ProductShop.DTOs.Category;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();
            InitializeDatasetFilePath("categories.json");

            //InitializeDatasetFilePath("categories.json");
            string inputJson = File.ReadAllText(filePath);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Problem 1 var result = ImportUsers(dbContext, inputJson);
            //Problem 2 var result = ImportProducts(dbContext, inputJson);

            var result = ImportCategories(dbContext, inputJson);
            Console.WriteLine(result);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new List<User>();
            foreach (ImportUserDto uDto in userDtos)
            {
                if (!IsValid(uDto))
                {
                    continue;
                }

                User user = Mapper.Map<User>(uDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 02 
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productsDTOs = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            var validProducts = new HashSet<Product>();

            foreach (var pDto in productsDTOs)
            {
                if(!IsValid(pDto))
                {
                    continue;
                }

                var product = Mapper.Map<Product>(pDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoriesDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            var categories = new HashSet<Category>();
            foreach (var cDto in categoriesDtos)
            {
                if(!IsValid(cDto))
                {
                    continue;
                }

                var category = Mapper.Map<Category>(cDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
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

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}