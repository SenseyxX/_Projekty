﻿using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;
using Warehouse.Domain.Item.Factories;

namespace Warehouse.Domain.Item.Entities
{
    public sealed class Item : Aggregate // Encja "Item" jest agregatem dla innych encji jak "LoanHistory"
    {
        public Item(
            Guid id,
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            State state,
            Guid ownerId,
            Guid actualOwnerId)
            : base(id)  // Zdefiniowany constructor z klasy Agregatu
        {
            Name = name; // Przypisanie wartości constructora do danego propa
            Description = description;
            CategoryId = categoryId;
            QualityLevel = qualityLevel;
            Quantity = quantity;
            State = state;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
            LoanHistories = new List<LoanHistory>(); // Stworzenie listy i przypisanie do propa
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; } // Zdefiniowanie wartości która występuje w encji "Category"
        public QualityLevel QualityLevel { get; private set; } // Zdefiniowanie wartości która występuje w enumie "QualityLevel".
        public int Quantity { get; private set; }
        public State State { get; private set; } // Zdefiniowanie wartości która występuje w enumie "State"
        public Guid OwnerId { get;  }
        public Guid ActualOwnerId { get; private set; }
        public ICollection<LoanHistory> LoanHistories { get; } // Stworzenie relacji jeden do wielu (jeden Item może mieć wiele LoanHistory)

        // ToDo Dodanie Zdjęcia

        // Metody wywoływane przy aktualizacji wartości w serwisie
        public bool UpdateName(string name) // Metoda wywoływana przy aktualizacji wartości w serwisie
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

        public bool UpdateOwner(Guid actualOwnerId)
        {
            if (ActualOwnerId == actualOwnerId)
            {
                return false;
            }

            ActualOwnerId = actualOwnerId;

            var loanHistory = LoanHistoryFactory.Create(
                DateTime.Now,
                Id,
                OwnerId,
                ActualOwnerId);

            LoanHistories.Add(loanHistory);

            return true;
        }
        
        public bool UpdateCategory(Guid categoryId)
        {
            if (CategoryId == categoryId)
            {
                return false;
            }

            CategoryId = categoryId;
            return true;
        }

        public bool UpdateQuality(QualityLevel qualityLevel)
        {
            if (QualityLevel == qualityLevel)
            {
                return false;
            }

            QualityLevel = qualityLevel;
            return true;
        }

        // Metody zmieniające stan Itemu funkcja która zastępuje usuwanie wartości przez zmiane statusu.
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
