namespace Footballers.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;

    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;
    
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .Where(x => x.Footballers.Any())
                .ToArray()
                .Select(c => new ExportCoachDto
                {
                    FootballersCount = c.Footballers.Count().ToString(),
                    Name = c.Name,
                    Footballers = c.Footballers
                    .Select(f => new ExportXmlFootballersDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Count())
                .ThenBy(c => c.Name)
                .ToArray();

            return Serialize<ExportCoachDto[]>(coaches, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(x => x.TeamsFootballers.Any(t => t.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new ExportTeamsDto
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                    .Where(t => t.Footballer.ContractStartDate >= date)
                    .OrderByDescending(t => t.Footballer.ContractEndDate)
                    .ThenBy(t => t.Footballer.Name)
                    .Select(f => new ExportFootballerDto
                    {
                        Name = f.Footballer.Name,
                        ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = f.Footballer.BestSkillType.ToString(),
                        PositionType = f.Footballer.PositionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();


            return JsonConvert.SerializeObject(teams, Formatting.Indented);
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
