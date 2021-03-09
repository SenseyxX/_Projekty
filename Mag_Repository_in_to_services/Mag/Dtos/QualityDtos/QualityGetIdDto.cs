using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.QualityDtos
{
        public class QualityGetIdDto
        {
                public int Id { get; set; }                
                public string Description { get; set; }
        }
}
