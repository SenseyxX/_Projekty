﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos
{
        public class SquadGetDto
        {
                public int Id { get; set; }
                public string SquadName { get; set; }
                public string SquadOwner { get; set; }
                public string City { get; set; }
        }
}
