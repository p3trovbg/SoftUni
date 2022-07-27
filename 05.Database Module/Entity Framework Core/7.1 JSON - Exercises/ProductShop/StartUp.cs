namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Data;
    using DTOs.User;
    using Models;

    using AutoMapper;
    using Newtonsoft.Json;
    using ProductShop.DTOs.Product;
    using ProductShop.DTOs.Category;
    using ProductShop.DTOs.CategoryProduct;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => 
            cfg.AddProfile(typeof(ProductShopProfile)));

            ProductShopContext dbContext = new ProductShopContext();
            // InitializeDatasetFilePath("products-in-range.json");

            //InitializeDatasetFilePath("categories.json");
            //string inputJson = File.ReadAllText(filePath);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Problem 1 var result = ImportUsers(dbContext, inputJson);
            //Problem 2 var result = ImportProducts(dbContext, inputJson);
            //Problem 3 var result = ImportCategories(dbContext, inputJson);
            //Problem 4 var result = ImportCategoryProducts(dbContext, inputJson);
            //Problem 5 var json = GetProductsInRange(dbContext);
            //Problem 6 var json = GetSoldProducts(dbContext);
            //var json = GetCategoriesByProductsCount(dbContext);

            var json = GetUsersWithProducts(dbContext);

            InitializeOutputFilePath("users-and-products.json");

            File.WriteAllText(filePath, json);
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
                if (!IsValid(pDto))
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
                if (!IsValid(cDto))
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

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductsDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            var categoryProducts = new HashSet<CategoryProduct>();

            foreach (var ctDto in categoryProductsDtos)
            {
                if (!IsValid(ctDto))
                {
                    continue;
                }

                var categoryProduct = Mapper.Map<CategoryProduct>(ctDto);
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ExportProductsInRangeDto>()
                .ToArray();

            return JsonConvert.SerializeObject(products);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(x => x.BuyerId.HasValue))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<ExportUsersWithSoldProductsDto>()
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                        .OrderByDescending(x => x.CategoryProducts.Count())
                        .ProjectTo<ExportCategoriesByProductDto>()
                        .ToArray();


            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                        .ToArray()
                        .Where(x => x.ProductsSold.Any(p => p.BuyerId.HasValue))
                        .Select(u => new
                        {
                            LastName = u.LastName,
                            Age = u.Age,
                            SoldProducts = new
                            {
                                Count = u.ProductsSold.Count(x => x.BuyerId.HasValue),
                                Products = u.ProductsSold.Where(p => p.BuyerId.HasValue)
                                .Select(p => new
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .ToArray()
                            }
                        })
                        .OrderByDescending(x => x.SoldProducts.Count);

            var output = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(output, settings);
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