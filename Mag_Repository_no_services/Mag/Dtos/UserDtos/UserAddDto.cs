using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.UserDtos
{
        public class UserAddDto
        {     
                [Required]
                [MaxLength(20)]
                public string Name { get; set; }
                [Required]
                [MaxLength(20)]
                public string LastName { get; set; }
                [Required]
                public int SquadId { get; set; }
                [Required]
                [MinLength(5)]
                public string PasswordHash { get; set; }
                [Required]
                [MaxLength(20)]
                public string Email { get; set; }
                [Required]
                [MaxLength(20)]
                public string PhoneNumber { get; set; }
        }
}
