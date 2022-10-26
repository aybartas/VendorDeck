using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string ProfilePictureUrl { get; set; }
    }
}
