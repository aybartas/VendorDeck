using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Exceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException() : base("Error creating user!"){}
        public CreateUserException(string message) : base(message) { }
        public CreateUserException(string message,Exception innerException) : base(message,innerException) { }
    }
}
