using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket;
using VendorDeck.Application.Responses;

namespace VendorDeck.Application.Mapping
{
    public class ResponseProfiles : Profile
    {
        public ResponseProfiles()
        {
            CreateMap<BaseResponse, RemoveItemFromBasketResponse>();
        }
    }
}
