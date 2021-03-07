using Mag.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Mag.Entities
{
    public class User          
    {

        public int Id { get; set; }
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



        public virtual Squad Squad { get; set; }
        // public virtual LoanHistory LoansHistories { get; set; }
        public ICollection<Item> Items { get; set; }
        // public ICollection<Item> MyItems { get; set; }

        }
}
