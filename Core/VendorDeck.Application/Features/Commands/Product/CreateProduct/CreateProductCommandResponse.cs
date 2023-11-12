using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
