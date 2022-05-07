using AutoMapper;
using VendorDeck.Entities.Concrete;
using VendorDeck.Entities.Dtos;

namespace VendorDeck.API.AutoMapper.Profiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItem, BasketItemDto>().

                ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)).
                ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price)).
                ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl)).
                ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Product.Brand)).
                ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Product.Type)).
                ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)).
                ReverseMap();
        }
    }
}
