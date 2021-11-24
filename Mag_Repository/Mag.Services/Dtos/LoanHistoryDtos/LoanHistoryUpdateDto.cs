using System;

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
