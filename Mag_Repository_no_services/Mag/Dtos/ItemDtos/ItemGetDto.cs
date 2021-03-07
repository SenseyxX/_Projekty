using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos
{
    public sealed class ItemGetDto
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
        }
}
