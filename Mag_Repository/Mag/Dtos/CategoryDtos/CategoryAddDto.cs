using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.CategoryDtos
{
        public class CategoryAddDto
        {
                [Required]
                [MaxLength(20)]
                public string CategoryName { get; set; }
                [MaxLength(100)]
                public string Description { get; set; }
        }
}
