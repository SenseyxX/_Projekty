using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Application.Dtos.Item
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
            CategoryState categoryState,
            Guid? ownerId,
            Guid actualOwnerId,
            IEnumerable<LoanHistoryDto>loanHistoryDto)
                : base (id,
                        name,
                        description,
                        categoryId,
                        qualityLevel,
                        quantity,
                        categoryState,
                        ownerId,
                        actualOwnerId)
            {
                  LoanHistoryDto = loanHistoryDto;
            }

            public IEnumerable<LoanHistoryDto> LoanHistoryDto { get; }

            public static explicit operator FullItemDto(Domain.Item.Entities.Item item)
                => new(
                       item.Id,
                       item.Name,
                       item.Description,
                       item.CategoryId,
                       item.QualityLevel,
                       item.Quantity,
                       item.CategoryState,
                       item.OwnerId,
                       item.ActualOwnerId,
                       item.LoanHistories.Select(loanHistory => (LoanHistoryDto)loanHistory));
    }
}
