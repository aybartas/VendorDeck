using AutoMapper;
using VendorDeck.Entities.Concrete;
using VendorDeck.API.Models;

namespace VendorDeck.API.AutoMapper.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.BuyerId)).
                ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems))
                .ReverseMap();
        }
    }
}
