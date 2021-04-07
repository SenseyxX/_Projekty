using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Model.Dtos
{
        class QualityDto
        {
                private QualityDto(string description)
                {
                        Description = description;
                }

                //public QualityLevel QualityLevel { get; set; }
                public string Description { get; set; }

                public static explicit operator QualityDto(Quality quality)
                        =>new (quality.Description);
        }
}
