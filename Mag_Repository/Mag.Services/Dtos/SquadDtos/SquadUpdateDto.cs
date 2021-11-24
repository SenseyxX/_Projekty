using System.ComponentModel.DataAnnotations;

namespace Mag.Dtos.SquadDtos
{
        public class SquadUpdateDto
        {
                [MaxLength(20)]
                public string SquadName { get; set; }
                public int SquadOwner { get; set; }
                [MaxLength(20)]
                public string City { get; set; }
        }
}
