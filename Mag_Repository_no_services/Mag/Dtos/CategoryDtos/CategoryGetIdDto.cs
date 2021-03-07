using Mag.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Dtos.CategoryDtos
{
        public class CategoryGetIdDto
        {
                public int Id { get; set; }                
                public string CategoryName { get; set; }              
                public string Description { get; set; }

                public virtual Item Item { get; set; }
        }
}
