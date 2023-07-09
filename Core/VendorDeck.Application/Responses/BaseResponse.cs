using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; } = new();

    }
}
