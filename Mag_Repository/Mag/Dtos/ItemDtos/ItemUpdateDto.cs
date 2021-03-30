using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.ItemDtos
{
    public class ItemUpdateDto
    {                
                [MaxLength(20)]
                public string ItemName { get; set; }               
                public int CategoryId { get; set; }
                public int QualityId { get; set; }
                public int Quantity { get; set; }
                public int OwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                [MaxLength(100)]
                public string Description { get; set; }
                //public byte[] ItemPhoto { get; set; }
                public string QrCode { get; set; }
        }
}
