namespace ProductShop
{
    using System.Linq;

    using DTOs.Category;
    using DTOs.CategoryProduct;
    using DTOs.Product;
    using DTOs.User;
    using Models;

    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.SellerFullName,
                    mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName,
                    mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName,
                    mo => mo.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<User, ExportUsersWithSoldProductsDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(s => 
                        s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<Product, ExportSoldProductShortInfoDto>();

            this.CreateMap<User, ExportSoldProductsFullInfoDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<User, ExportUsersWithFullProductInfoDto>()
                .ForMember(d => d.SoldProductsInfo,
                    mo => mo.MapFrom(s => s));
        }
    }
}
