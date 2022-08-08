namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.DataProcessor.ImportDto;
    using System;
    using System.Globalization;
    using System.Linq;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            this.CreateMap<ImportFootballerDto, Footballer>()
                   .ForMember(d => d.BestSkillType,
                mo => mo.MapFrom(x => (BestSkillType)x.BestSkillType))
                .ForMember(d => d.PositionType,
                mo => mo.MapFrom(x => (PositionType)x.PositionType));

            this.CreateMap<ImportCoachDto, Coach>()
                .ForMember(d => d.Footballers,
                mo => mo.MapFrom(x => x.Footballers));
        }
    }
}
