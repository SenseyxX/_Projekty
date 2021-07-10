using System;
using System.Collections.Generic;
using Warehouse.Persistence.Entities.Abstractions;
using Warehouse.Persistence.Factories;

namespace Warehouse.Persistence.Entities.Item.Entities
{
    public sealed class Item : Aggregate // Encja "Item" jest agregatem dla innych encji jak "LoanHistory"
    {
        public Item(Guid id,
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel, // Zdefiniowanie enumaratora
            int quantity,
            State state,
            Guid? ownerId,
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
        public Guid CategoryId { get; } // Zdefiniowanie wartości która występuje w encji "Category"
        public QualityLevel QualityLevel { get; } // Zdefiniowanie wartości która występuje w enumie "QualityLevel". ToDo Dodać możliwość edycji QualityLevel 
        public int Quantity { get; private set; }
        public State State { get; private set; } // Zdefiniowanie wartości która występuje w enumie "State"
        public Guid? OwnerId { get; private set; } 
        public Guid ActualOwnerId { get; }
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

        public bool UpdateOwner(Guid ownerId) // ToDo CZy tu nie powinniśmy aktualizaować aCtualOwner ?
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
