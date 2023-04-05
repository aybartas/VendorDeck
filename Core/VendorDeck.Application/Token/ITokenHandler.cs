using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int lifeTimeDays);
    }
}
