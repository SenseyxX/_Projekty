using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.SquadDtos
{
        public class SquadGetIdDto
        {
                public int Id { get; set; }
                public string SquadName { get; set; }
                public string SquadOwner { get; set; }
                public string City { get; set; }
        }
}
