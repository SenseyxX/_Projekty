using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Model.Dtos
{
        class ItemDto
        {
                private ItemDto(string name,string description)
                {
                        Name = name;
                        Description = description;
                }

                public string Name { get;}
                public string Description { get;}
                //public Guid CategoryId { get; set; }
                //public Guid QualityId { get; set; }
                //public Quality Quality { get; set; }
                //public ICollection<LoanHistory> LoanHistories { get; set; }
                //public Guid? OwnerId { get; set; }
                //public Guid ActualOwnerId { get; set; }

                public static explicit operator ItemDto(Item item)
                        =>new (item.Name,item.Description);
        }
}
