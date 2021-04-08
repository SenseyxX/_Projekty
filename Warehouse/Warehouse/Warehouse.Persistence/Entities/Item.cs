using System;
using System.Collections.Generic;

namespace Warehouse.Persistence.Entities
{
    public sealed class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public Guid CategoryId { get; set; }
        public Guid QualityId { get; set; }
        public Quality.Quality Quality { get; set; }
        public ICollection<LoanHistory> LoanHistories { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid ActualOwnerId { get; set; }
    }
}
