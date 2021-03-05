using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Entities
{
        public class Squad
        {
                public int Id { get; set; }
                public string SquadName { get; set; }
                public string SquadOwner { get; set; }
                public string City { get; set; }

                public virtual Collection<User> Users { get; set; }

        }
}
