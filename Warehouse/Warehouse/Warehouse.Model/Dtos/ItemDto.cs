using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class ItemDto
    {
        private ItemDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        //ToDo
        //public Guid CategoryId { get; set; }
        //public Guid QualityId { get; set; }
        //public Quality Quality { get; set; }
        //public ICollection<LoanHistory> LoanHistories { get; set; }
        //public Guid? OwnerId { get; set; }
        //public Guid ActualOwnerId { get; set; }

        public static explicit operator ItemDto(Item item)
                => new (item.Name, item.Description);
    }
}
