using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.ItemDtos
{
    public class ItemGetIdDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public int QualityId { get; set; }
        public int Quantity { get; set; }
        public int OwnerId { get; set; }
        public int ActualOwnerId { get; set; }
        public string Description { get; set; }

        //public byte[] ItemPhoto { get; set; }
        public string QrCode { get; set; }



        //[ForeignKey("CategoryForeignKey")]
        //public virtual Category Category { get; set; }
        public virtual Quality Quality { get; set; }
        public virtual LoanHistory LoansHistories { get; set; }

        public virtual User User { get; set; }
        // public virtual User ActualUser { get; set; }
    }
}
