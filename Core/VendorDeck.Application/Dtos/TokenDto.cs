using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
