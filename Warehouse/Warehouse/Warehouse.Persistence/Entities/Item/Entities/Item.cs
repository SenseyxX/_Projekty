﻿using System;
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
            int quantity,
            State state,
            Guid? ownerId,
            Guid actualOwnerId)
            : base(id)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            QualityLevel = qualityLevel;
            Quantity = quantity;
            State = state;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
            LoanHistories = new List<LoanHistory>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; }
        public QualityLevel QualityLevel { get; private set; } 
        public int Quantity { get;private set; }
        public State State { get; private set; }
        public Guid? OwnerId { get; private set; }
        public Guid ActualOwnerId { get; private set; }
        public ICollection<LoanHistory> LoanHistories { get; }

        public bool UpdateName(string name)
        {
            if (Name == name)
            {
                return false;
            }

            Name = name;
            return true;
        }

        public bool UpdateDescription(string description)
        {
            if (Description == description)
            {
                return false;
            }

            Description = description;
            return true;
        }

        public bool UpdateQuantity(int quantity)
        {
            if (Quantity == quantity)
            {
                return false;
            }

            Quantity = quantity;
            return true;
        }

        public bool UpdateOwner(Guid ownerId)
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
            if (State == State.Active)
            {
                return false;
            }

            State = State.Active;
            return true;
        }

        public bool Delete()
        {
            if (State == State.Deleted)
            {
                return false;
            }

            State = State.Deleted;
            return true;
        }
    }
}
