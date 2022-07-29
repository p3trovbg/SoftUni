using CarDealer.Models;
using CarDealer.DTO.Part;
using CarDealer.DTO.Supplier;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Car;

using AutoMapper;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartsDto, Part>();
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();
            this.CreateMap<Customer, ExportOrderedCustomerDto>();
            this.CreateMap<Car, ExportToyotaCarDto>();

            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartsCount,
                mo => mo.MapFrom(p => p.Parts.Count));

            this.CreateMap<Part, ExportPartInfoDto>();
            this.CreateMap<Car, ExportCarInfoDto>();
        }
    }
}
