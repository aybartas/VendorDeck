﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Features.Queries.User.GetCurrentUser
{
    public class GetCurrentUserQueryResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address LastAddress { get; set; }
    }
}
