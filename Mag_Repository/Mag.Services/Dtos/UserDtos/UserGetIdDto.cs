﻿using System.Collections.Generic;

namespace Mag.Dtos.UserDtos
{
        public class UserGetIdDto
    {
                public int Id { get; set; }                
                public string Name { get; set; }
                public string LastName { get; set; }
                public int SquadId { get; set; }                            
                public string Email { get; set; }               
                public string PhoneNumber { get; set; }



                // public virtual Squad Squad { get; set; }
                // public virtual LoanHistory LoansHistories { get; set; }
                public ICollection<Item> Items { get; set; }
                public ICollection<Item> MyItems { get; set; }
        }
}
