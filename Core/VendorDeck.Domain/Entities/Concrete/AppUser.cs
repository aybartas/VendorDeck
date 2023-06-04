using Microsoft.AspNetCore.Identity;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
