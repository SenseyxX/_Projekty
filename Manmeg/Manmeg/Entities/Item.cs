using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manmeg.Entities
{
        public class Item
        {
                public int Id { get; set; }
                public string ItemName { get; set; }
                public string QualityId { get; set; }
                public int Quantity { get; set; }
                public int OwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                public string Description { get; set; }
                public byte[] ItemPhoto { get; set; }
                public string QrCode { get; set; }



                public virtual Category Category { get; set; }
                public virtual Quality Quality { get; set; }  
                public ICollection<User> User { get; set; }

        }
}
