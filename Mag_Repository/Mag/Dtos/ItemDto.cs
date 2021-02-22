using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos
{
    public sealed class ItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int QualityId { get; set; }
    }
}
