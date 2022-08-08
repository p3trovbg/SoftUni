namespace Footballers.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Xml.Serialization;

    using Data;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;

    using AutoMapper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachDtos = XmlDeserializer<ImportCoachDto[]>(xmlString, "Coaches");

            var coaches = new List<Coach>();
            var sb = new StringBuilder();
            ;
            var culture = CultureInfo.InvariantCulture;
            foreach (var dto in coachDtos)
            {
                var footballers = new List<Footballer>();

                foreach (var footballerDto in dto.Footballers)
                {
                    bool isValidStartDate = DateTime
                        .TryParseExact(footballerDto.ContractStartDate,
                        "dd/MM/yyyy",
                        culture,
                        DateTimeStyles.None,
                        out DateTime firstDate);

                    bool isValidEndDate = DateTime
                        .TryParseExact(footballerDto.ContractEndDate,
                        "dd/MM/yyyy",
                        culture,
                        DateTimeStyles.None,
                        out DateTime endDate);

                    bool isValidDate = false;

                    if (isValidStartDate && isValidEndDate)
                    {
                        isValidDate = firstDate < endDate;
                    }

                    if (IsValid(footballerDto) && isValidDate)
                    {

                        var footballer = Mapper.Map<Footballer>(footballerDto);
                        footballers.Add(footballer);
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                if (IsValid(dto))
                {
                    var coach = Mapper.Map<Coach>(dto);
                    coach.Footballers = footballers;
                    coaches.Add(coach);

                    sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            var teams = new List<Team>();
            var sb = new StringBuilder();

            var allIds = context.Footballers.Select(x => x.Id).ToHashSet();

            foreach (var dto in teamDtos)
            {               
                if(!IsValid(dto) || int.Parse(dto.Trophies) <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                else
                {
                    var validFootballers = new List<TeamFootballer>();

                    var footballersDtos = dto.Footballers.Distinct();
                    foreach (var id in footballersDtos)
                    {
                        if (!allIds.Contains(id))
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            validFootballers.Add(new TeamFootballer
                            {
                                FootballerId = id,
                            });
                        }
                    }

                    teams.Add(new Team
                    {
                        Name = dto.Name,
                        Nationality = dto.Nationality,
                        Trophies = int.Parse(dto.Trophies),
                        TeamsFootballers = validFootballers
                    });
                    sb.AppendLine(string.Format(SuccessfullyImportedTeam, dto.Name, validFootballers.Count));
                }
            }


            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T XmlDeserializer<T>(string xmlString, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(xmlString);
            T dtos = (T)serializer.Deserialize(reader);

            return dtos;
        }
    }
}
