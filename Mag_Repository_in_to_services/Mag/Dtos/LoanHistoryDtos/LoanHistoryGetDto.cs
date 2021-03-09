using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos
{
        public class LoanHistoryGetDto
        {
                public int Id { get; set; }
                public int ItemId { get; set; }
                public int LastOwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                public DateTime LoanDate { get; set; }
        }
}
