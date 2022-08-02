namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using Theatre.Data;
    using Theatre.DataProcessor.ImportDto;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;

    using AutoMapper;
    using Newtonsoft.Json;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var playDtos = XmlDeserializer<List<ImportPlayDto>>("Plays", xmlString);
            var plays = new List<Play>();

            var sb = new StringBuilder();

            foreach (var dto in playDtos)
            {
                var isGenre = Enum.TryParse<Genre>(dto.Genre, out Genre genreType);
                var isTimeValid = TimeSpan.Parse(dto.Duration).TotalMinutes >= 60;

                if (!IsValid(dto) || !isTimeValid || !isGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                plays.Add(Mapper.Map<Play>(dto));
                sb.AppendLine(String.Format(SuccessfulImportPlay, dto.Title, dto.Genre, dto.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var castDtos = XmlDeserializer<List<ImportCastDto>>("Casts", xmlString);
            var casts = new List<Cast>();

            var sb = new StringBuilder();
            foreach (var dto in castDtos)
            {
                if(!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                casts.Add(Mapper.Map<Cast>(dto));

                var role = dto.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {dto.FullName} as a {role} character!");
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatreTicketDtos = JsonConvert.DeserializeObject<List<ImportTheatreDto>>(jsonString);
            var theatres = new List<Theatre>();

            var sb = new StringBuilder();

            foreach (var dto in theatreTicketDtos)
            {
                if(!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tickets = new List<Ticket>();

                foreach (var ticketDto in dto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    tickets.Add(Mapper.Map<Ticket>(ticketDto));
                }

                theatres.Add(Mapper.Map<Theatre>(dto));

                sb.AppendLine(String.Format(SuccessfulImportTheatre, dto.Name, tickets.Count));
            }

            context.Theatres.AddRange(theatres);
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

        private static T XmlDeserializer<T>(string rootTag, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootTag);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            T dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (T)serializer.Deserialize(reader);
            }

            return dtos;
        }
    }
}
