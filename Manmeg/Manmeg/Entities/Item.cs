using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manmeg.Entities
{
        public class Items
        {
                public int Id { get; set; }
                public string ItemName { get; set; }
                public int QualityId { get; set; }
                public int Quantity { get; set; }
                public int OwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                public string Description { get; set; }
                public byte[] ItemPhoto { get; set; }
                public string QrCode { get; set; }

        }
}
