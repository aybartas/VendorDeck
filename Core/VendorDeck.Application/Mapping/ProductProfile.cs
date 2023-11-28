using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.ViewModels;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductViewModel,Product>();
            CreateMap<Product, ProductViewModel>();

        }
    }
}
