using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AddUserCommand
    {
        public string Name { get; }
        public string LastName { get; }
        public string PasswordHash { get; set; }
        public string Email { get; }
        public string PhoneNumber { get; }
    }
}
