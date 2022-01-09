using AutoMapper;
using Century.Business.Models;
using Century.WebApp.Models;

namespace Century.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Phone, PhoneViewModel>().ReverseMap();
            CreateMap<Email, EmailViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            
        }
    }
}
