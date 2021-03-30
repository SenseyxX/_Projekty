using System.ComponentModel.DataAnnotations;

namespace Mag.Dtos.CategoryDtos
{
        public class CategoryUpdateDto
        {
                [MaxLength(20)]
                public string CategoryName { get; set; }
                [MaxLength(100)]
                public string Description { get; set; }
        }
}
