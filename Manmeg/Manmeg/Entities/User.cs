using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manmeg.Entities
{
        public class User
        {
                public int Id { get; set; }
                public string Name { get; set; }
                public string LastName { get; set; }
                public string PasswordHash { get; set; }
                public string Email { get; set; }
                public string PhoneNumber { get; set; }
                public int SquadId { get; set; }


                public virtual Squad Squad { get; set; }
                public virtual Item Item { get; set; }
                public virtual LoanHistory LoanHistory { get; set; }

        }
}
