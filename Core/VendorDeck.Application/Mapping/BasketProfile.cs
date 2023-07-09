using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Mapping
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.BuyerId))
                        .ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems));

            CreateMap<BasketDto, Basket>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.BuyerId))
                        .ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems));

        }
    }
}
