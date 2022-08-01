using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using AutoMapper;

using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
           cfg.AddProfile(typeof(ProductShopProfile)));

            var dbContext = new ProductShopContext();
            
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            InitializeDatasetFilePath("products.xml");
            string inputXml = File.ReadAllText(filePath);

            //var result = ImportUsers(dbContext, inputXml);
            var result = ImportProducts(dbContext, inputXml);
            ////var result = ImportCategories(dbContext, inputXml);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var dtos = Deserialize<ImportUserDto[]>(inputXml, "Users");
            var users = dtos
                .Select(x => Mapper.Map<User>(x))
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var dtos = Deserialize<ImportProductDto[]>(inputXml, "Products");
            var products = Mapper.Map<ICollection<Product>>(dtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var dtos = Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            var categories = dtos
                .Select(x => Mapper.Map<Category>(x))
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            //Import the categories and products ids from the provided file categories-products.xml.
            //If provided category or product id, doesn’t exists, skip the whole entry!
            var dtos = Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            var categoryProducts = dtos
                .Where(x => x.ProductId != null &&
                            x.CategoryId != null)
                .Select(x => Mapper.Map<CategoryProduct>(x))
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            var dtos = (T)serializer
                    .Deserialize(reader);

            return dtos;
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