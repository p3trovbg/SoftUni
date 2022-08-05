using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Theatre;
using Theatre.Data;
using Theatre.DataProcessor;

[TestFixture]
public class Export_000_001
{
    private IServiceProvider serviceProvider;
    private static Assembly CurrentAssembly;

    [SetUp]
    public void Setup()
    {
        CurrentAssembly = typeof(StartUp).Assembly;

        Mapper.Reset();
        Mapper.Initialize(cfg => cfg.AddProfile(GetType("TheatreProfile")));

        this.serviceProvider = ConfigureServices<TheatreContext>("Theatre");
    }

    [Test]
    public void ExportTheatresZeroTest()
    {
        var context = serviceProvider.GetService<TheatreContext>();

        SeedDatabase(context);

        var actualOutputValue = Serializer.ExportTheatres(context, 6);
        var actualOutput = JToken.Parse(actualOutputValue);

        var expectedOutputValue = "[{\"Name\":\"Gothic Theatre\",\"Halls\":8,\"TotalIncome\":982.98,\"Tickets\":[{\"Price\":84.64,\"RowNumber\":5},{\"Price\":83.78,\"RowNumber\":5},{\"Price\":82.84,\"RowNumber\":1},{\"Price\":82.07,\"RowNumber\":1},{\"Price\":80.08,\"RowNumber\":2},{\"Price\":77.95,\"RowNumber\":2},{\"Price\":77.37,\"RowNumber\":3},{\"Price\":68.88,\"RowNumber\":5},{\"Price\":61.01,\"RowNumber\":4},{\"Price\":58.99,\"RowNumber\":5},{\"Price\":55.33,\"RowNumber\":2},{\"Price\":51.37,\"RowNumber\":4},{\"Price\":44.85,\"RowNumber\":2},{\"Price\":40.54,\"RowNumber\":5},{\"Price\":17.34,\"RowNumber\":3},{\"Price\":15.94,\"RowNumber\":1}]},{\"Name\":\"Draken\",\"Halls\":6,\"TotalIncome\":696.75,\"Tickets\":[{\"Price\":98.82,\"RowNumber\":2},{\"Price\":93.41,\"RowNumber\":1},{\"Price\":86.14,\"RowNumber\":5},{\"Price\":76.77,\"RowNumber\":1},{\"Price\":68.56,\"RowNumber\":1},{\"Price\":68.05,\"RowNumber\":1},{\"Price\":62.14,\"RowNumber\":3},{\"Price\":55.96,\"RowNumber\":1},{\"Price\":45.18,\"RowNumber\":3},{\"Price\":23.61,\"RowNumber\":5},{\"Price\":13.83,\"RowNumber\":3},{\"Price\":4.28,\"RowNumber\":2}]},{\"Name\":\"Rex Theatre\",\"Halls\":6,\"TotalIncome\":556.68,\"Tickets\":[{\"Price\":87.5,\"RowNumber\":2},{\"Price\":81.62,\"RowNumber\":1},{\"Price\":76.63,\"RowNumber\":4},{\"Price\":72.54,\"RowNumber\":5},{\"Price\":69.76,\"RowNumber\":3},{\"Price\":44.35,\"RowNumber\":1},{\"Price\":42.35,\"RowNumber\":4},{\"Price\":35.55,\"RowNumber\":4},{\"Price\":33.25,\"RowNumber\":3},{\"Price\":13.13,\"RowNumber\":2}]}]";
        var expectedOutput = JToken.Parse(expectedOutputValue);

        var expected = expectedOutput.ToString(Formatting.None);
        var actual = actualOutput.ToString(Formatting.None);

        Assert.That(actual, Is.EqualTo(expected).NoClip,
            $"{nameof(Serializer.ExportTheatres)} output is incorrect!");
    }

    private static void SeedDatabase(TheatreContext context)
    {
        var datasetsJson = "{\"Play\":[{\"Id\":1,\"Title\":\"Candida\",\"Duration\":\"03:40:00\",\"Rating\":8.2,\"Genre\":0,\"Description\":\"A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled Pinter Pause, which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.\",\"Screenwriter\":\"Roger Nciotti\"},{\"Id\":2,\"Title\":\"The Persianasd\",\"Duration\":\"02:21:00\",\"Rating\":6.5,\"Genre\":1,\"Description\":\"What to do about Shaw? So many of his plays zing as comedies and also still work as social commentary. Looking over his canon (pun sort of intended), it struck me that this one of the 'Plays Pleasant' series might be most important.\",\"Screenwriter\":\"Carmina Pollak\"},{\"Id\":3,\"Title\":\"Playboy of the Western World\",\"Duration\":\"03:40:00\",\"Rating\":8.2,\"Genre\":2,\"Description\":\"A guyat Pinter turns into a debata Much of this has to do with the fabled Pinter Pause, which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.\",\"Screenwriter\":\"Roger Ncioasdtti\"}],\"Cast\":[{\"Id\":1,\"FullName\":\"Clarie Ethelston\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":1},{\"Id\":2,\"FullName\":\"Morganica Irons\",\"IsMainCharacter\":true,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":1},{\"Id\":3,\"FullName\":\"Tarrah Scouler\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":1},{\"Id\":4,\"FullName\":\"Joseito Melmoth\",\"IsMainCharacter\":true,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":2},{\"Id\":5,\"FullName\":\"Pippy Ennever\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":2},{\"Id\":6,\"FullName\":\"Cosetta Mauditt\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":2},{\"Id\":7,\"FullName\":\"Smitty Beaty\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":3},{\"Id\":8,\"FullName\":\"Delphine Crone\",\"IsMainCharacter\":true,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":3},{\"Id\":9,\"FullName\":\"Perice Ricker\",\"IsMainCharacter\":false,\"PhoneNumber\":\"+44-35-745-2774\",\"PlayId\":3}],\"Theatre\":[{\"Id\":1,\"Name\":\"Rex Theatre\",\"NumberOfHalls\":6,\"Director\":\"Sorcha Banting\"},{\"Id\":2,\"Name\":\"Gothic Theatre\",\"NumberOfHalls\":8,\"Director\":\"Thornton Wilder\"},{\"Id\":3,\"Name\":\"Congress Theater\",\"NumberOfHalls\":7,\"Director\":\"Earvin Van der Kruys\"},{\"Id\":4,\"Name\":\"Colonial Theatre\",\"NumberOfHalls\":5,\"Director\":\"Kissiah Sansun\"},{\"Id\":5,\"Name\":\"Draken\",\"NumberOfHalls\":6,\"Director\":\"Margery Piatti\"}],\"Ticket\":[{\"Id\":1,\"Price\":55.33,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":1},{\"Id\":2,\"Price\":83.33,\"RowNumber\":6,\"PlayId\":2,\"TheatreId\":4},{\"Id\":3,\"Price\":13.32,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":4},{\"Id\":4,\"Price\":79.01,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":4},{\"Id\":5,\"Price\":89.31,\"RowNumber\":10,\"PlayId\":2,\"TheatreId\":4},{\"Id\":6,\"Price\":52.17,\"RowNumber\":8,\"PlayId\":1,\"TheatreId\":4},{\"Id\":7,\"Price\":65.96,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":4},{\"Id\":8,\"Price\":88.76,\"RowNumber\":1,\"PlayId\":2,\"TheatreId\":4},{\"Id\":9,\"Price\":14.13,\"RowNumber\":8,\"PlayId\":1,\"TheatreId\":4},{\"Id\":10,\"Price\":12.51,\"RowNumber\":9,\"PlayId\":3,\"TheatreId\":4},{\"Id\":11,\"Price\":85.09,\"RowNumber\":1,\"PlayId\":2,\"TheatreId\":4},{\"Id\":12,\"Price\":73.64,\"RowNumber\":8,\"PlayId\":1,\"TheatreId\":4},{\"Id\":13,\"Price\":86.21,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":4},{\"Id\":14,\"Price\":93.48,\"RowNumber\":3,\"PlayId\":2,\"TheatreId\":4},{\"Id\":15,\"Price\":54.72,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":4},{\"Id\":16,\"Price\":85.64,\"RowNumber\":4,\"PlayId\":3,\"TheatreId\":4},{\"Id\":17,\"Price\":75.62,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":4},{\"Id\":18,\"Price\":11.07,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":4},{\"Id\":19,\"Price\":10.37,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":4},{\"Id\":20,\"Price\":47.25,\"RowNumber\":8,\"PlayId\":2,\"TheatreId\":3},{\"Id\":21,\"Price\":98.49,\"RowNumber\":9,\"PlayId\":3,\"TheatreId\":4},{\"Id\":22,\"Price\":15.74,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":3},{\"Id\":23,\"Price\":91.67,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":4},{\"Id\":24,\"Price\":98.82,\"RowNumber\":2,\"PlayId\":3,\"TheatreId\":5},{\"Id\":25,\"Price\":68.05,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":5},{\"Id\":26,\"Price\":51.09,\"RowNumber\":8,\"PlayId\":3,\"TheatreId\":5},{\"Id\":27,\"Price\":45.18,\"RowNumber\":3,\"PlayId\":2,\"TheatreId\":5},{\"Id\":28,\"Price\":44.33,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":5},{\"Id\":29,\"Price\":62.14,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":5},{\"Id\":30,\"Price\":68.56,\"RowNumber\":1,\"PlayId\":2,\"TheatreId\":5},{\"Id\":31,\"Price\":93.41,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":5},{\"Id\":32,\"Price\":86.14,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":5},{\"Id\":33,\"Price\":17.47,\"RowNumber\":6,\"PlayId\":2,\"TheatreId\":5},{\"Id\":34,\"Price\":13.83,\"RowNumber\":3,\"PlayId\":1,\"TheatreId\":5},{\"Id\":35,\"Price\":15.59,\"RowNumber\":6,\"PlayId\":3,\"TheatreId\":5},{\"Id\":36,\"Price\":13.07,\"RowNumber\":8,\"PlayId\":2,\"TheatreId\":5},{\"Id\":37,\"Price\":31.62,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":5},{\"Id\":38,\"Price\":55.96,\"RowNumber\":1,\"PlayId\":3,\"TheatreId\":5},{\"Id\":39,\"Price\":58.37,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":5},{\"Id\":40,\"Price\":76.77,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":5},{\"Id\":41,\"Price\":84.76,\"RowNumber\":9,\"PlayId\":3,\"TheatreId\":5},{\"Id\":42,\"Price\":73.58,\"RowNumber\":9,\"PlayId\":2,\"TheatreId\":5},{\"Id\":43,\"Price\":51.5,\"RowNumber\":6,\"PlayId\":1,\"TheatreId\":5},{\"Id\":44,\"Price\":89.58,\"RowNumber\":5,\"PlayId\":2,\"TheatreId\":4},{\"Id\":45,\"Price\":23.61,\"RowNumber\":5,\"PlayId\":2,\"TheatreId\":5},{\"Id\":46,\"Price\":40.18,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":3},{\"Id\":47,\"Price\":15.94,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":2},{\"Id\":48,\"Price\":44.35,\"RowNumber\":1,\"PlayId\":2,\"TheatreId\":1},{\"Id\":49,\"Price\":17.85,\"RowNumber\":10,\"PlayId\":1,\"TheatreId\":1},{\"Id\":50,\"Price\":26.36,\"RowNumber\":10,\"PlayId\":3,\"TheatreId\":1},{\"Id\":51,\"Price\":42.35,\"RowNumber\":4,\"PlayId\":2,\"TheatreId\":1},{\"Id\":52,\"Price\":76.63,\"RowNumber\":4,\"PlayId\":1,\"TheatreId\":1},{\"Id\":53,\"Price\":90.55,\"RowNumber\":8,\"PlayId\":3,\"TheatreId\":1},{\"Id\":54,\"Price\":97.74,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":1},{\"Id\":55,\"Price\":90.09,\"RowNumber\":6,\"PlayId\":1,\"TheatreId\":1},{\"Id\":56,\"Price\":13.13,\"RowNumber\":2,\"PlayId\":3,\"TheatreId\":1},{\"Id\":57,\"Price\":69.76,\"RowNumber\":3,\"PlayId\":2,\"TheatreId\":1},{\"Id\":58,\"Price\":87.5,\"RowNumber\":2,\"PlayId\":1,\"TheatreId\":1},{\"Id\":59,\"Price\":33.25,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":1},{\"Id\":60,\"Price\":83.52,\"RowNumber\":7,\"PlayId\":1,\"TheatreId\":1},{\"Id\":61,\"Price\":60.21,\"RowNumber\":10,\"PlayId\":2,\"TheatreId\":1},{\"Id\":62,\"Price\":73.74,\"RowNumber\":6,\"PlayId\":3,\"TheatreId\":1},{\"Id\":63,\"Price\":57.49,\"RowNumber\":9,\"PlayId\":1,\"TheatreId\":1},{\"Id\":64,\"Price\":72.06,\"RowNumber\":8,\"PlayId\":2,\"TheatreId\":1},{\"Id\":65,\"Price\":72.54,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":1},{\"Id\":66,\"Price\":35.55,\"RowNumber\":4,\"PlayId\":1,\"TheatreId\":1},{\"Id\":67,\"Price\":87.22,\"RowNumber\":6,\"PlayId\":3,\"TheatreId\":1},{\"Id\":68,\"Price\":77.95,\"RowNumber\":2,\"PlayId\":2,\"TheatreId\":2},{\"Id\":69,\"Price\":81.62,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":1},{\"Id\":70,\"Price\":81.4,\"RowNumber\":8,\"PlayId\":3,\"TheatreId\":2},{\"Id\":71,\"Price\":80.91,\"RowNumber\":6,\"PlayId\":3,\"TheatreId\":2},{\"Id\":72,\"Price\":82.07,\"RowNumber\":1,\"PlayId\":2,\"TheatreId\":2},{\"Id\":73,\"Price\":51.37,\"RowNumber\":4,\"PlayId\":1,\"TheatreId\":2},{\"Id\":74,\"Price\":92.92,\"RowNumber\":6,\"PlayId\":3,\"TheatreId\":2},{\"Id\":75,\"Price\":47.19,\"RowNumber\":8,\"PlayId\":2,\"TheatreId\":2},{\"Id\":76,\"Price\":80.08,\"RowNumber\":2,\"PlayId\":1,\"TheatreId\":2},{\"Id\":77,\"Price\":84.64,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":2},{\"Id\":78,\"Price\":68.88,\"RowNumber\":5,\"PlayId\":2,\"TheatreId\":2},{\"Id\":79,\"Price\":40.54,\"RowNumber\":5,\"PlayId\":1,\"TheatreId\":2},{\"Id\":80,\"Price\":58.99,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":2},{\"Id\":81,\"Price\":77.37,\"RowNumber\":3,\"PlayId\":2,\"TheatreId\":2},{\"Id\":82,\"Price\":44.85,\"RowNumber\":2,\"PlayId\":1,\"TheatreId\":2},{\"Id\":83,\"Price\":83.78,\"RowNumber\":5,\"PlayId\":3,\"TheatreId\":2},{\"Id\":84,\"Price\":12.53,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":2},{\"Id\":85,\"Price\":55.33,\"RowNumber\":2,\"PlayId\":1,\"TheatreId\":2},{\"Id\":86,\"Price\":17.34,\"RowNumber\":3,\"PlayId\":3,\"TheatreId\":2},{\"Id\":87,\"Price\":18.75,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":2},{\"Id\":88,\"Price\":61.01,\"RowNumber\":4,\"PlayId\":2,\"TheatreId\":2},{\"Id\":89,\"Price\":82.84,\"RowNumber\":1,\"PlayId\":1,\"TheatreId\":2},{\"Id\":90,\"Price\":29.69,\"RowNumber\":7,\"PlayId\":2,\"TheatreId\":2},{\"Id\":91,\"Price\":4.28,\"RowNumber\":2,\"PlayId\":3,\"TheatreId\":5}]}";

        var datasets = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(datasetsJson);

        foreach (var dataset in datasets)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        context.SaveChanges();
    }

    private static Type GetType(string modelName)
    {
        var modelType = CurrentAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == modelName);

        Assert.IsNotNull(modelType, $"{modelName} model not found!");

        return modelType;
    }

    private static IServiceProvider ConfigureServices<TContext>(string databaseName)
        where TContext : DbContext
    {
        var services = ConfigureDbContext<TContext>(databaseName);

        var context = services.GetService<TContext>();

        try
        {
            context.Model.GetEntityTypes();
        }
        catch (InvalidOperationException ex) when (ex.Source == "Microsoft.EntityFrameworkCore.Proxies")
        {
            services = ConfigureDbContext<TContext>(databaseName, useLazyLoading: true);
        }

        return services;
    }

    private static IServiceProvider ConfigureDbContext<TContext>(string databaseName, bool useLazyLoading = false)
        where TContext : DbContext
    {
        var services = new ServiceCollection()
           .AddDbContext<TContext>(t => t
           .UseInMemoryDatabase(Guid.NewGuid().ToString())
           );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}