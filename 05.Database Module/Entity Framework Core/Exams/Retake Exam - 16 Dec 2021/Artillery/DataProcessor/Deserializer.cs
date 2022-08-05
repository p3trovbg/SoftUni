namespace Artillery.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Artillery.Data;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Data.Models;
    using AutoMapper;
    using System.Linq;
    using Newtonsoft.Json;
    using Artillery.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var countryDtos = Deserialize<ImportCountryDto[]>(xmlString, "Countries");
            var countries = new List<Country>();

            var sb = new StringBuilder();

            foreach (var dto in countryDtos)
            {
                if(IsValid(dto))
                {
                    countries.Add(Mapper.Map<Country>(dto));
                    sb
                     .AppendLine($"Successfully import {dto.CountryName} with {dto.ArmySize} army personnel.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var manufacturerDtos = Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");
            var manufacturers = new HashSet<Manufacturer>();
            var sb = new StringBuilder();

            foreach (var dto in manufacturerDtos)
            {
                if(IsValid(dto) && !manufacturers.Any(x => x.ManufacturerName == dto.ManufacturerName))
                {
                        manufacturers.Add(Mapper.Map<Manufacturer>(dto));
                        var foundedInfo = dto.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                        sb
                          .AppendLine($"Successfully import manufacturer {dto.ManufacturerName} founded in {foundedInfo[foundedInfo.Length - 2]}, {foundedInfo[foundedInfo.Length - 1]}.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var shellDtos = Deserialize<ImportShellDto[]>(xmlString, "Shells");
            var shells = new List<Shell>();
            var sb = new StringBuilder();

            foreach (var dto in shellDtos)
            {
                if(IsValid(dto))
                {
                    shells.Add(Mapper.Map<Shell>(dto));
                    sb.AppendLine($"Successfully import shell caliber #{dto.Caliber} weight {dto.ShellWeight} kg.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            var guns = new List<Gun>();
            var sb = new StringBuilder();

            foreach (var dto in gunDtos)
            {
                bool isValidType = Enum.TryParse<GunType>(dto.GunType, out GunType type);
                if (IsValid(dto) && isValidType)
                {
                    var gun = Mapper.Map<Gun>(dto);
                    gun.GunType = type;
                    guns.Add(gun);
                    sb
                     .AppendLine($"Successfully import gun {dto.GunType} with a total weight of {dto.GunWeight} kg. and barrel length of {dto.BarrelLength:F2} m.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            var dtos = (T)serializer.Deserialize(reader);

            return dtos;
        }
    }
}
