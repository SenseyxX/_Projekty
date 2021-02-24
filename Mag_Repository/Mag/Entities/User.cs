using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Entities
{
    public class User : BaseEntity         
    {        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }       


        // public virtual Squad Squad { get; set; }
        // public virtual LoanHistory LoansHistories { get; set; }
        public ICollection<Item> Items { get; set; }
        // public ICollection<Item> MyItems { get; set; }

    }
}
