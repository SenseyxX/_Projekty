using System;
using System.Collections.Generic;
using Warehouse.Persistence.Entities.Abstractions;
using Warehouse.Persistence.Factories;

namespace Warehouse.Persistence.Entities.Item.Entities
{
    public sealed class Item : Aggregate
    {
        public Item(Guid id,
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            ItemState itemState,
            Guid? ownerId,
            Guid actualOwnerId)
            : base(id)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            QualityLevel = qualityLevel;
            ItemState = itemState;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
            LoanHistories = new List<LoanHistory>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; }
        public QualityLevel QualityLevel { get; }
        public ItemState ItemState { get; private set; }
        public Guid? OwnerId { get; private set; }
        public Guid ActualOwnerId { get; }
        public ICollection<LoanHistory> LoanHistories { get; }

        public bool ChangeName(string name)
        {
            if (Name == name)
            {
                return false;
            }

            Name = name;
            return true;
        }

        public bool ChangeDescription(string description)
        {
            if (Description == description)
            {
                return false;
            }

            Description = description;
            return true;
        }

        public bool ChangeOwner(Guid ownerId)
        {
            if (OwnerId == ownerId)
            {
                return false;
            }

            OwnerId = ownerId;

            var loanHistory = LoanHistoryFactory.Create(
                DateTime.Now,
                Id,
                ActualOwnerId,
                OwnerId.Value);
            LoanHistories.Add(loanHistory);

            return true;
        }

        public bool Activate()
        {
            if (ItemState == ItemState.Active)
            {
                return false;
            }

            ItemState = ItemState.Active;
            return true;
        }

        public bool Delete()
        {
            if (ItemState == ItemState.Deleted)
            {
                return false;
            }

            ItemState = ItemState.Deleted;
            return true;
        }
    }
}
