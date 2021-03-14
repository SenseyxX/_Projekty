using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Mag.Entities
{
        public class Squad
        {
                public int Id { get; set; }
                [MaxLength(20)]
                public string SquadName { get; set; }
                public int SquadOwner { get; set; }
                [MaxLength(20)]
                public string City { get; set; }

                public virtual Collection<User> Users { get; set; }

        }
}
