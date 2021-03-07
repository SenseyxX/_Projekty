using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.SquadDtos
{
        public class SquadGetIdDto
        {
                public int Id { get; set; }                
                public string SquadName { get; set; }                
                public int SquadOwner { get; set; }                
                public string City { get; set; }
        }
}
