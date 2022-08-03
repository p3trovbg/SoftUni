namespace Theatre
{
    using AutoMapper;
    using System.Linq;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;
    using Theatre.DataProcessor.ImportDto;

    class TheatreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TheatreProfile()
        {
            this.CreateMap<ImportPlayDto, Play>();
            this.CreateMap<ImportCastDto, Cast>();
            this.CreateMap<ImportTheatreDto, Theatre>();
            this.CreateMap<ImportTicketDto, Ticket>();

            this.CreateMap<Ticket, ExportTicketDto>();
            this.CreateMap<Theatre, ExportTheatreDto>()
                .ForMember(d => d.TotalInCome,
                t => t.MapFrom(x => x.Tickets
                            .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                            .Sum(x => x.Price)))
                .ForMember(d => d.Tickets, 
                t => t.MapFrom(x => x.Tickets
                .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                .OrderByDescending(x => x.Price)));

            this.CreateMap<Cast, ExportActorDto>();
            this.CreateMap<Play, ExportPlayDto>();
        }
    }
}
