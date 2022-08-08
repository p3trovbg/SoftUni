
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellDtos = context.Shells
                            .Where(x => x.ShellWeight > shellWeight)
                            .ProjectTo<ExportShellDto>()
                            .OrderBy(x => x.ShellWeight)
                            .ToArray();

            var json = JsonConvert.SerializeObject(shellDtos, Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var gunDtos = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(x => x.BarrelLength)
                .Select(x => new XmlExportGunDto
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight.ToString(),
                    BarrelLength = x.BarrelLength.ToString(),
                    Range = x.Range.ToString(),
                    Countries = 
                        x.CountriesGuns
                        .Where(c => c.Country.ArmySize > 4_500_000)
                        .OrderBy(c => c.Country.ArmySize)
                        .Select(c => new ExportCountryDto
                        {
                            CountryName = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize.ToString()
                        })
                        .ToArray()
                })         
                .ToArray();

            return Serialize<XmlExportGunDto[]>(gunDtos, "Guns");
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
