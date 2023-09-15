using AutoMapper;
using VendorDeck.Application.ViewModels;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order> ();
        }
    }
}
