using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Dtos
{
    public class UploadImageDto
    {
        public bool IsSuccess { get; set; }
        public Uri Url { get; set; }
        public string Error { get; set; }
    }
}
