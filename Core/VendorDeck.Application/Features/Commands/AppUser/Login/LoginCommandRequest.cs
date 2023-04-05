using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
