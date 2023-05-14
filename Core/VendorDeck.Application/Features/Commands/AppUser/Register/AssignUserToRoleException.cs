using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Features.Commands.AppUser.Register
{
    public class AssignUserToRoleException : Exception
    {

        public AssignUserToRoleException(string username,string role) : base($"Error assiging role {role} to user ${username}")
        {
            
        }
    }
}
