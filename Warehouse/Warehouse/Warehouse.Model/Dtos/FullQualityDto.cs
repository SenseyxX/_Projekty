using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Model.Dtos
{
   public sealed class FullQualityDto : QualityDto
    {
        private FullQualityDto(Guid id,string description)
        {
            Description = description;
        }
        //ToDo
        //public QualityLevel QualityLevel { get; set; }        

        public static explicit operator FullQualityDto(Quality quality)
                => new(quality.Id, quality.Description);
    }
}
