using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Mag.Entities
{
        public class Quality
        {
                public int Id { get; set; }
                public int QualityNumber { get; set; }
                [MaxLength(20)]
                public string Description { get; set; }


                public virtual ICollection<Item> Items { get; set; }
        }
}
