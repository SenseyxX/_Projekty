using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.UserDtos
{
        public class UserUpdateDto
    {
            
            public string Name { get; set; }
            public string LastName { get; set; }
            public int SquadId { get; set; }
            public string PasswordHash { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
}
