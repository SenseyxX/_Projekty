using System;

namespace Mag.Entities
{
    public class LoanHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int LastOwnerId { get; set; } 
        public int ActualOwnerId { get; set; }
        public DateTime LoanDate { get; set; }


        // public ICollection<Item> items { get; set; }
        // public ICollection<User> users { get; set; }
    }
}
