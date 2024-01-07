using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.ViewModels;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
