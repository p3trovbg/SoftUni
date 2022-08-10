namespace Theatre.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;
    using System.Text;
    using System.Collections.Generic;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                     .Where(x => x.NumberOfHalls >= numbersOfHalls &&
                                 x.Tickets.Count > 20)
                    .ProjectTo<ExportTheatreDto>()
                    .OrderByDescending(x => x.NumberOfHalls)
                    .ThenBy(x => x.Name)
                    .ToList();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString(@"hh\:mm\:ss"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                            .Where(x => x.IsMainCharacter)
                            .Select(a => new ExportActorDto
                            {
                                FullName = a.FullName,
                                MainCharacter = $"Plays main character in '{x.Title}'."
                            })
                            .OrderByDescending(x => x.FullName)
                            .ToList()
                })
                .ToList()
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToList();

            return Serialize<List<ExportPlayDto>>(plays, "Plays");
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();
            var name = new XmlRootAttribute(rootName);
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);
            var serializer = new XmlSerializer(typeof(T), name);
            
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dto, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
