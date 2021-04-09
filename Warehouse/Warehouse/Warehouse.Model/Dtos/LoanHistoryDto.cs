using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class LoanHistoryDto
    {
        private LoanHistoryDto(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
        public DateTime Timestamp { get; set; }
        //ToDo
        //public Guid ItemId { get; set; }
        //public Guid BorrowerId { get; set; }
        //public Guid ReceiverId { get; set; }

        public static explicit operator LoanHistoryDto(LoanHistory loanHistory)
                => new (loanHistory.Timestamp);
    }
}
