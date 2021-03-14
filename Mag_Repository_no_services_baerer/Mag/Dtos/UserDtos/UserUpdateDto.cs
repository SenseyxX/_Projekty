using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.UserDtos
{
        public class UserUpdateDto
        {
                [MaxLength(20)]
                public string Name { get; set; }
                [MaxLength(20)]
                public string LastName { get; set; }
                public int SquadId { get; set; }
                public string PasswordHash { get; set; }
                [MaxLength(20)]
                public string Email { get; set; }
                [MaxLength(20)]
                public string PhoneNumber { get; set; }
        }
}
