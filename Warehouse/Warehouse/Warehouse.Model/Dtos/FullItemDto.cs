﻿using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullItemDto : ItemDto // Klasa która ma za zadanie odizolować wybrane propy od głownej encji od edycji/wyświetlania w serwisach/controllerach/repozytoriach
                                              // Klasy FullDto głównie są wykorzystowwane przy wyświetlaniu bardziej szczegółowych informacji                                     
    {
        private FullItemDto(
            Guid id,
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            State state,
            Guid? ownerId,
            Guid actualOwnerId,
            IEnumerable<LoanHistoryDto>loanHistoryDtos)
<<<<<<< HEAD
                : base(id, name, description, qualityLevel, quantity, state, ownerId, actualOwnerId)
            {
                  CategoryId = categoryId; 
=======
                : base (id,
                        name,
                        description,
                        categoryId,
                        qualityLevel,
                        quantity,
                        state,
                        ownerId,
                        actualOwnerId)
            {
                  CategoryId = categoryId;
                  QualityLevel = qualityLevel;
                  Quantity = quantity;
                  State = state;
                  OwnerId = ownerId;
                  ActualOwnerId = actualOwnerId;
>>>>>>> main
                  LoanHistoryDtos = loanHistoryDtos;
             }

<<<<<<< HEAD
            public Guid CategoryId { get; }                        
=======
>>>>>>> main
            public IEnumerable<LoanHistoryDto> LoanHistoryDtos { get; }

            public static explicit operator FullItemDto(Item item)
            => new(item.Id,
                   item.Name,
                   item.Description,
                   item.CategoryId,
                   item.QualityLevel,
                   item.Quantity,
                   item.State,
                   item.OwnerId,
                   item.ActualOwnerId,
                   item.LoanHistories.Select(loanHistory => (LoanHistoryDto)loanHistory));
    }
}
