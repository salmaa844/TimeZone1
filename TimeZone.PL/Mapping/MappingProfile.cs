using AutoMapper;
using TimeZone.DAL.Models;
using TimeZone.PL.Areas.Dashboard.ViewModels;


namespace TimeZone.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFormVM, Service >().ReverseMap();
            CreateMap<Service, ServiceVM>();
            CreateMap<Service, ServiceDetailsVM>();
            //////////////
            CreateMap<PortfoiloFormVM, Portfolio>().ReverseMap();
            CreateMap<Portfolio, PortfolioVM>();
            CreateMap<Portfolio, PortfolioDetailsVM>();
            //////////////
            CreateMap<ProductFormVM, Product>().ReverseMap();
            CreateMap<Product, ProductVM>();
            CreateMap<Product, ProductDetailsVM>();
            //////////////
            CreateMap<SlideShowFormVM, SlideShow>().ReverseMap();
            CreateMap<SlideShow, SlideShowVM>();
            //////////
            CreateMap<ItemFormVM, Item>().ReverseMap();
            CreateMap<Item, ItemVM>();
           
            //////////////

        }


    }
}
