namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using System;
    using System.Linq;

    class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            this.CreateMap<ImportCountryDto, Country>();
            this.CreateMap<ImportManufacturerDto, Manufacturer>();
            this.CreateMap<ImportShellDto, Shell>();
            this.CreateMap<CountryIdDto, CountryGun>()
                .ForMember(d => d.CountryId,
                mo => mo.MapFrom(s => s.Id));
            this.CreateMap<ImportGunDto, Gun>()
                 .ForMember(d => d.CountriesGuns,
                 mo => mo.MapFrom(s => s.Countries));
        }
    }
}