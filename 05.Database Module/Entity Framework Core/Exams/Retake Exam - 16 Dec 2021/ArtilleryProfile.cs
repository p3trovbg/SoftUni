namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
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
            this.CreateMap<ImportCountryIdsDto, CountryGun>()
                .ForMember(d => d.CountryId,
                mo => mo.MapFrom(x => x.Id));
            this.CreateMap<ImportGunDto, Gun>()
                .ForMember(d => d.CountriesGuns,
                mo => mo.MapFrom(x => x.Countries));

            this.CreateMap<Gun, ExportGunDto>()
                .ForMember(d => d.Range,
                mo => mo.MapFrom(x => x.Range > 3000 ? "Long-range" : "Regular range"))
                .ForMember(d => d.GunType,
                mo => mo.MapFrom(x => x.GunType.ToString()));

            this.CreateMap<Shell, ExportShellDto>()
                .ForMember(d => d.Guns,
                mo => mo.MapFrom(x => x.Guns))
                .ForMember(d => d.Guns,
                mo => mo.MapFrom(x => x.Guns
                .Where(x => x.GunType.Equals(GunType.AntiAircraftGun))
                .OrderByDescending(x => x.GunWeight)));


            this.CreateMap<Country, ExportCountryDto>();    
            this.CreateMap<Gun, XmlExportGunDto>();
        }
    }
}