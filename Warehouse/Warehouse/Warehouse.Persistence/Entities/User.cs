using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Persistence.Entities
{
    class User:Entity
    {        
        public string Name { get; set; }
        public string LastName { get; set; }        
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }       
    }
}
