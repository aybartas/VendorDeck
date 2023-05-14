using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Features.Commands.AppUser
{
    public class CreateUserCommandResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new();
    }
}
