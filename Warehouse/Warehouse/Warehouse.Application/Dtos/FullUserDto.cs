using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.User.Entities;
using Warehouse.Domain.User.Enumeration;

namespace Warehouse.Application.Dtos
{
    public sealed class FullUserDto : UserDto
    {
        private FullUserDto(Guid id,
            string name,
            string lastName,
            string email,
            string phoneNumber,
            PermissionLevel permissionLevel,
            CategoryState categoryState,
            Guid squadId,
            Guid teamId,
            IEnumerable<ItemDto> ownedItems,
            IEnumerable<ItemDto> storedItems)
            :base (id,
                   name,
                   lastName,
                   email,
                   phoneNumber,
                   squadId,
                   teamId)
            {
                PermissionLevel = permissionLevel;
                CategoryState = categoryState;
                CategoryState = categoryState;
                OwnedItems = ownedItems;
                StoredItems = storedItems;
            }

            public CategoryState CategoryState { get; private set; }
            public PermissionLevel PermissionLevel { get; }
            public IEnumerable<ItemDto> OwnedItems { get; }
            public IEnumerable<ItemDto> StoredItems { get; }

            public static explicit operator FullUserDto(User user)
                  => new(user.Id,
                         user.Name,
                         user.LastName,
                         user.Email,
                         user.PhoneNumber,
                         user.PermissionLevel,
                         user.CategoryState,
                         user.SquadId,
                         user.TeamId,
                         user.OwnedItems.Select(ownedItems => (ItemDto) ownedItems),
                         user.StoredItems.Select(storesItems => (ItemDto) storesItems));
    }
}
