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
    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();
            InitializeDatasetFilePath("users.json");

            //InitializeDatasetFilePath("categories.json");
            string inputJson = File.ReadAllText(filePath);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            var result = ImportUsers(dbContext, inputJson);
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