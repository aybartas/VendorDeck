using AutoMapper;
using VendorDeck.Application.ViewModels;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Mappings
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
