using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using BookShop;
using BookShop.Data;
using BookShop.Models;
using BookShop.Models.Enums;
using BookShop.Initializer;

[TestFixture]
public class Test_Open_002
{
    private IServiceProvider serviceProvider;

    [SetUp]
    public void Setup()
    {
        string databaseName = Guid.NewGuid().ToString();

        var options = new DbContextOptionsBuilder<BookShopContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        var services = new ServiceCollection()
            .AddDbContext<BookShopContext>(b => b.UseInMemoryDatabase(databaseName));

        serviceProvider = services.BuildServiceProvider();
    }

    [Test]
    public void ValidateOutput()
    {
        var service = serviceProvider.GetService<BookShopContext>();

        DbInitializer.Seed(service);

        int booksDeleted = StartUp.RemoveBooks(service);

        var assertService = serviceProvider.GetService<BookShopContext>();

        var bookCount = assertService.Books.Count();

        Assert.AreEqual(34, booksDeleted, "Incorrect amount of books deleted!");

        Assert.AreEqual(156, bookCount, "Incorrect amount of books left in the database");
    }
}