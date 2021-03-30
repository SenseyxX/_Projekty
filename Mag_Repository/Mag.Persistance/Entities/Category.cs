using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Mag.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string CategoryName { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
