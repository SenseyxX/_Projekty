using System.ComponentModel.DataAnnotations;

namespace Mag.Dtos.SquadDtos
{
        public class SquadAddDto
        {
                [Required]
                [MaxLength(20)]
                public string SquadName { get; set; }
                [Required]
                public int SquadOwner { get; set; }
                [MaxLength(20)]
                public string City { get; set; }
        }
}
