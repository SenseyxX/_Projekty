using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class UserFactory
    {
        public static User Create(string name, string lastname, string passwordhash, string email, string phonenumber)
            => new(Guid.NewGuid(), name, lastname, passwordhash, email, phonenumber);
    }
}
