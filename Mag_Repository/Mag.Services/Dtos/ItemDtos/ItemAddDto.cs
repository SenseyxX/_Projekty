using System.ComponentModel.DataAnnotations;

namespace Mag.Dtos.ItemDtos
{
    public class ItemAddDto
    {
        [Required]
        [MaxLength(20)]
                public string ItemName { get; set; }
                [Required]
                public int CategoryId { get; set; }
                [Required]
                public int QualityId { get; set; }
                [Required]
                public int Quantity { get; set; }
                [Required]
                public int OwnerId { get; set; }
                public int ActualOwnerId { get; set; }
                [MaxLength(100)]
                public string Description { get; set; }
                //public byte[] ItemPhoto { get; set; }
                public string QrCode { get; set; }
        }
}
