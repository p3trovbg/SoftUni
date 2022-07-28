using CarDealer.Models;

using CarDealer.DTO.Part;
using CarDealer.DTO.Supplier;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Car;

using AutoMapper;

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
        }
    }
}
