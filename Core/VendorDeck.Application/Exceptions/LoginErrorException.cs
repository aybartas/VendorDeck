﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Exceptions
{
    public class LoginErrorException : Exception
    {
        public LoginErrorException() : base("Login is failed")
        {

        }
    }
}
