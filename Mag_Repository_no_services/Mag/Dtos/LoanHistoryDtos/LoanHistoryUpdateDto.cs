using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.LoanHistoryDtos
{
        public class LoanHistoryUpdateDto
        {
                
                public int ItemId { get; set; }
                public int LastOwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                public DateTime LoanDate { get; set; }
        }
}
