using AutoMapper;
using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Mapping
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItem, BasketItemDto>()
                .ForPath(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForPath(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForPath(dest => dest.Brand, opt => opt.MapFrom(src => src.Product.Brand))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForPath(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForPath(dest => dest.Type, opt => opt.MapFrom(src => src.Product.Type))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<BasketItemDto, BasketItem>()
                .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForPath(dest => dest.Product.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForPath(dest => dest.Product.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForPath(dest => dest.Product.Price, opt => opt.MapFrom(src => src.Price))
                .ForPath(dest => dest.Product.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForPath(dest => dest.Product.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        }
    }
}
