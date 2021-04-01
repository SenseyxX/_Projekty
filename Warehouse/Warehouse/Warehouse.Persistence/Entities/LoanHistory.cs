using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Persistence.Entities
{
    public sealed class LoanHistory : Entity
    {
        //  public int LastOwnerId { get; set; }
        //  public int ActualOwnerId { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
