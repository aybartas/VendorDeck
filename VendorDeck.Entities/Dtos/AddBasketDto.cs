using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Entities.Dtos
{
    public class AddBasketDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
